using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace EncryptionGenie
{

    public class Controller
    {

        private int masterSaltSize;
        private string strSaltHMAC = "thisishmacsalt";
        private string strSaltEnc = "thisisencsalt";


        //default Constructor fo initialization
        public Controller()
        {
            masterSaltSize = 16; // 128-bit salt                        
        }

        //Function to find key sizes (in Bytes) of various algorithms dynamically
        public int FindKeySizeInBytes(string algorithm)
        {
            int KeySize;
            switch (algorithm.ToUpper())
            {
                case "3DES":
                    KeySize = TripleDES.Create().LegalKeySizes[0].MinSize;
                    break;
                case "AES128":
                    KeySize = Aes.Create().LegalKeySizes[0].MinSize;
                    break;
                case "AES256":
                    KeySize = Aes.Create().LegalKeySizes[0].MaxSize;
                    break;
                case "SHA256":
                    KeySize = SHA256.Create().HashSize;
                    break;
                case "SHA512":
                    KeySize = SHA512.Create().HashSize;
                    break;
                default:
                    throw new ArgumentException("Unsupported cipher/hashing algorithm.");
            }

            return KeySize / 8;
        }

        //Function to find one block size (in Bytes) of various algorithms dynamically
        public int FindBlockSizeInBytes(string algorithm)
        {
            int blockSize;
            switch (algorithm.ToUpper())
            {
                case "3DES":
                    blockSize = TripleDES.Create().LegalBlockSizes[0].MaxSize;
                    break;
                case "AES128":
                    blockSize = Aes.Create().LegalBlockSizes[0].MinSize;
                    break;
                case "AES256":
                    blockSize = Aes.Create().LegalBlockSizes[0].MaxSize;
                    break;
                default:
                    throw new ArgumentException("Unsupported cipher/hashing algorithm.");
            }

            return blockSize / 8;
        }

        //Function to generate master key using user's password, a randomly generated salt, random no. of interations and user's selected Hash Algorithm
        public byte[] GenerateMasterKey(string password, int KeySize, byte[] salt, int Iterations, string hashAlgo)
        {

            // Use PBKDF2 to derive the key from the password and salt

            HashAlgorithmName hashAlgorithmName = new HashAlgorithmName(hashAlgo);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, hashAlgorithmName))
            {
                byte[] key = pbkdf2.GetBytes(KeySize);
                byte[] masterKey = new byte[masterSaltSize + KeySize];

                // Concatenate the salt and key into the master key

                Array.Copy(salt, 0, masterKey, 0, masterSaltSize);
                Array.Copy(key, 0, masterKey, masterSaltSize, KeySize);

                return masterKey;
            }
        }


        //Function to generate Encryption Key and Hash Key based off masterkey and salt

        public byte[] GenerateKeyPBKDF2(byte[] masterkey, int KeySize, byte[] salt, int Iterations)
        {
            // Use PBKDF2 to derive the key from the password and salt

            using (var pbkdf2 = new Rfc2898DeriveBytes(masterkey, salt, Iterations))
            {
                byte[] key = pbkdf2.GetBytes(KeySize);
                return key;
            }
        }


        //Function to dynamically generate Symmetric Algorithmn class instance based on algorithm name

        static SymmetricAlgorithm CreateCipher(string algorithm)
        {
            switch (algorithm)
            {
                case "3DES":
                    return TripleDES.Create();
                case "AES128":
                    return Aes.Create();
                case "AES256":
                    return Aes.Create();
                default:
                    throw new ArgumentException("Unsupported cipher algorithm.");
            }
        }

        //Function to create HMAC based off given Hash Algorithmn and hmac key
        //The hash includes metadata, IV and Ciphertext in the same order

        static byte[] CreateHMAC(string hashAlgo, byte[] hmacKey, byte[] metadataBytes, byte[] iv, byte[] cipherText)
        {
            HMAC hmac;
            switch (hashAlgo)
            {
                case "SHA256":
                    hmac = new HMACSHA256(hmacKey); break;
                case "SHA512":
                    hmac = new HMACSHA512(hmacKey); break;
                default:
                    throw new ArgumentException("Unsupported hashing algorithm.");
            }


            byte[] bytesToHash = new byte[metadataBytes.Length + iv.Length + cipherText.Length];

            // Concatenate the salt and key into the master key

            Array.Copy(metadataBytes, 0, bytesToHash, 0, metadataBytes.Length);
            Array.Copy(iv, 0, bytesToHash, metadataBytes.Length, iv.Length);
            Array.Copy(cipherText, 0, bytesToHash, metadataBytes.Length + iv.Length, cipherText.Length);

            byte[] hashBytes = hmac.ComputeHash(bytesToHash);

            return hashBytes;
        }

        //Function that encrypts user's file and returns encrypted file path
        //It performs the following in order:
        //1. Generate random Iterations and Salt to derive mater key
        //2. Derive master key, encryption key and HMAC key
        //3. Read user's file and generate cipher text
        //4. Generate Metadata JSON and its Base64
        //5. Generate Hash of Metadata, IV, Ciphertext for integrity check
        //6. Generate final Encrypted file that includes metadata, hash, IV, Ciphertext in the same order
        //7. Retrun the encrypted file path to UI

        public string encryptFile(string FilePath, string EncAlgo, string HashAlgo, string SecretText)
        {
            try
            {
                Console.WriteLine("Encryption of file " + FilePath + "has started.");

                byte[] cipherText;

                string encryptedFilePath = Path.ChangeExtension(FilePath, string.Concat(Path.GetExtension(FilePath), ".enc"));
                
                Dictionary<string, object> metadata = new Dictionary<string, object>();                

                //Generate random number of iterations for master key generation

                int Iterations = new Random().Next(10000, 100000);

                Console.WriteLine("Generating random salt for master key.");

                int encKeySize = FindKeySizeInBytes(EncAlgo);
                int hmacKeySize = FindKeySizeInBytes(HashAlgo);

                byte[] masterSaltBytes = RandomNumberGenerator.GetBytes(masterSaltSize);
                string masterSalt = BitConverter.ToString(masterSaltBytes);

                //Generate master key of size that is compatible to both Cipher Algo and Hash Algo
                byte[] masterKey = GenerateMasterKey(SecretText, Math.Max(encKeySize, hmacKeySize), masterSaltBytes, Iterations, HashAlgo);

                // Derive encryption key using PBKDF2
                byte[] saltEnc = Encoding.UTF8.GetBytes(strSaltEnc);
                byte[] encryptionKey = new byte[encKeySize];
                encryptionKey = GenerateKeyPBKDF2(masterKey, encKeySize, saltEnc, 1);

                // Derive HMAC key using PBKDF2                
                byte[] saltHMAC = Encoding.UTF8.GetBytes(strSaltHMAC);
                byte[] hmacKey = new byte[hmacKeySize];
                hmacKey = GenerateKeyPBKDF2(masterKey, hmacKeySize, saltHMAC, 1);

                Console.WriteLine("Master Key, Encryption Key and HMAC Key for encryption process has been generated.");

                // Generate IV of one block size
                int blockSize = FindBlockSizeInBytes(EncAlgo);
                byte[] iv = RandomNumberGenerator.GetBytes(blockSize);

                // Read the user's file
                byte[] plaintextBytes = File.ReadAllBytes(FilePath);


                //Crate an instance of the selected encryption algorithm 
                using (SymmetricAlgorithm encAlgo = CreateCipher(EncAlgo))
                {
                    // Use CBC mode and Padding as ISO10126 to prevent padding oracle

                    encAlgo.Key = encryptionKey;
                    encAlgo.IV = iv;
                    encAlgo.Mode = CipherMode.CBC;
                    encAlgo.Padding = PaddingMode.ISO10126;

                    //Create an encryptor that encrypts bytes passed in a CryptoStream and writes in memory stream
                    ICryptoTransform encryptor = encAlgo.CreateEncryptor();

                    using (MemoryStream ms = new MemoryStream())
                    {                        
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(plaintextBytes, 0, plaintextBytes.Length);
                            cs.FlushFinalBlock(); //ensures all blocks are encrypted
                            cs.Dispose();

                        }
                        ms.Close();

                        //fetch the cipher Text from memory stream
                        cipherText = ms.ToArray();
                    }

                }


                //Generate metadata and store it in a dictionary

                metadata.Add("EncAlgo", EncAlgo);
                metadata.Add("HashAlgo", HashAlgo);
                metadata.Add("Iterations", Iterations);
                metadata.Add("Salt", masterSalt);

                Console.WriteLine("Encryption completed. Generating metadata.");

                // Obfuscate metadata with base64 encoding

                string metadataJson = JsonSerializer.Serialize(metadata);
                byte[] metadataBytes = Encoding.UTF8.GetBytes(metadataJson);
                string metadataBase64 = Convert.ToBase64String(metadataBytes);
                byte[] metadataBase64Bytes = Encoding.UTF8.GetBytes(metadataBase64);


                // Generate a hash for metadata, IV and Ciphertext            
                byte[] hashBytes = CreateHMAC(HashAlgo, hmacKey, metadataBytes, iv, cipherText);

                // Save the metadata, hash, IV and Ciphertext in a .enc file to file system
                using (BinaryWriter writer = new BinaryWriter(File.Open(encryptedFilePath, FileMode.Create)))
                {
                    writer.Write(BitConverter.GetBytes(metadataBase64Bytes.Length));
                    writer.Write(metadataBase64Bytes);
                    writer.Write(hashBytes);
                    writer.Write(iv);
                    writer.Write(cipherText);
                }

                return encryptedFilePath;
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.ToString());
                return "";
            }

            // End of Encryption function

        }


        //Function that decrypts user's file and returns decrypted file path
        //It performs the following in order:
        //1. Reads encrypted file and fetches metadata like Hash and Encryption algorithms, Iterations, master Salt
        //2. Receives password and recreates master key based on the salt and hash algorithm
        //3. Regenerates Encryption and HMAC key from the master key
        //4. Fetches hash, IV, Ciphertext from the encrypted file
        //5. Recalculates hash and checks for the intigrity of the decrypted file
        //6. Decrypts the cipher text and saves the file to file system
        public string decryptFile(string encFilePath, string SecretText)
        {
            try
            {
                byte[] plainTextBytes;
                string decryptedFilePath = Path.ChangeExtension(encFilePath, Path.GetExtension(encFilePath).Replace(".enc", ""));


                Console.WriteLine("Decryption of file " + encFilePath + " has started.");


                using (BinaryReader reader = new BinaryReader(File.Open(encFilePath, FileMode.Open)))
                {

                    Console.WriteLine("Loading encrypted file into memory.");

                    // Read the metadata from encrypted file into a dictionary object                
                    int metadataLength = BitConverter.ToInt32(reader.ReadBytes(sizeof(Int32)), 0); // first 4 byte has length of metadata Base64
                    reader.BaseStream.Seek(sizeof(Int32), SeekOrigin.Begin); // read metadata from 5th byte onwards
                    byte[] metadataBase64Bytes = reader.ReadBytes(metadataLength);
                    string metadataBase64String = Encoding.UTF8.GetString(metadataBase64Bytes);
                    byte[] metadataBytes = Convert.FromBase64String(metadataBase64String);

                    Dictionary<string, object> metadata = JsonSerializer.Deserialize<Dictionary<string, object>>(metadataBytes);


                    string HashAlgo = metadata["HashAlgo"].ToString();
                    string EncAlgo = metadata["EncAlgo"].ToString();
                    int Iterations = int.Parse(metadata["Iterations"].ToString());
                    string masterSalt = metadata["Salt"].ToString();

                    Console.WriteLine("Fetching metadata from the file.");


                    Console.WriteLine("Regenerating Master Key, Encryption Key and HMAC Key.");

                    int encKeySize = FindKeySizeInBytes(EncAlgo);
                    int hmacKeySize = FindKeySizeInBytes(HashAlgo);

                    //Generate master key of size that is compatible to both Cipher Algo and Hash Algo
                    byte[] masterSaltBytes = masterSalt.Split('-').Select(s => byte.Parse(s, System.Globalization.NumberStyles.HexNumber)).ToArray();
                    byte[] masterKey = GenerateMasterKey(SecretText, Math.Max(encKeySize, hmacKeySize), masterSaltBytes, Iterations, HashAlgo);


                    // Derive encryption key using PBKDF2 based on the master key
                    byte[] saltEnc = Encoding.UTF8.GetBytes(strSaltEnc);
                    byte[] encryptionKey = new byte[encKeySize];
                    encryptionKey = GenerateKeyPBKDF2(masterKey, encKeySize, saltEnc, 1);



                    // Derive HMAC key using PBKDF2 based on the master key
                    byte[] saltHMAC = Encoding.UTF8.GetBytes(strSaltHMAC);
                    byte[] hmacKey = new byte[hmacKeySize];
                    hmacKey = GenerateKeyPBKDF2(masterKey, hmacKeySize, saltHMAC, 1);


                    // Read the hash from the encrypted file                
                    byte[] hashBytes = reader.ReadBytes(hmacKeySize);

                    Console.WriteLine("Reading the IV of one block size.");

                    // Read the IV 
                    int ivLength = FindBlockSizeInBytes(EncAlgo);
                    byte[] iv = reader.ReadBytes(ivLength);

                    // Read the ciphertext
                    int ciphertextLength = (int)reader.BaseStream.Length - 4 - metadataLength - hmacKeySize - ivLength;
                    byte[] ciphertextBytes = reader.ReadBytes(ciphertextLength);

                    // Recompute the hash
                    Console.WriteLine("Computing hash for integrity check.");
                    byte[] computedHashBytes = CreateHMAC(HashAlgo, hmacKey, metadataBytes, iv, ciphertextBytes);

                    //Compare the hashes for integrity check
                    if (!computedHashBytes.SequenceEqual(hashBytes))
                    {
                        Console.WriteLine("Hash did not match. The file seems to be altered or corrupted.");
                        throw new Exception("Hash mismatch");
                    }


                    //Create a symmetric algorithm instance based on the algorithmn fetched in metadata
                    using (SymmetricAlgorithm encAlgo = CreateCipher(EncAlgo))
                    {
                        encAlgo.Key = encryptionKey;
                        encAlgo.IV = iv;
                        encAlgo.Mode = CipherMode.CBC;
                        encAlgo.Padding = PaddingMode.ISO10126;

                        //Create decryptor
                        ICryptoTransform decryptor = encAlgo.CreateDecryptor();

                        using (MemoryStream ms = new MemoryStream())
                        {                            
                            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                            {
                                cs.Write(ciphertextBytes, 0, ciphertextBytes.Length);
                                cs.FlushFinalBlock();
                                cs.Dispose();

                            }

                            ms.Close();
                            plainTextBytes = ms.ToArray();
                        }
                    }


                    // dump the decrypted data into file system
                    using (BinaryWriter writer = new BinaryWriter(File.Open(decryptedFilePath, FileMode.Create)))
                    {
                        writer.Write(plainTextBytes);
                    }


                }

                return decryptedFilePath;
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.ToString());
                return "";
            }
        }

    }
}
