**EncryptionGenie:**

EncryptionGenie is a lightweight tool that allows users to encrypt and decrypt their files using various encryption algorithms. It also has inbuilt file integrity check based on HMAC hashing.

- Built with C# and .Net 7.0 Core
- Cross-platform (Can be used in any OS that has .Net 7.0 installed)
- Lightweight
- Both GUI and CLI based
- Extremely fast
- Has inbuilt file integrity check
- Can encrypt/decrypt any type of file

**Source Code:**

1. Program.cs

This is the main entry point of the program that checks the operating system the application is being run. If Windows, it runs the GUI (WinForm) that is easy to use and if its Linux and Others, it automatically starts the CLI based utility. Log4net that logs the telemetry is initialized here.

1. EncryptForm.cs / DecryptForm.cs

These are classes based on Windows Form that generate the UI of the encryption and decryption page. Each of these take input from the users and validate them.

[image](https://github.com/Krishna-Paudel/EncryptionGenie/assets/52009770/cbf39b65-3308-44ff-a5d5-c3a3596ab75b)

[image](https://github.com/Krishna-Paudel/EncryptionGenie/assets/52009770/895edab3-7020-4ff0-82d4-a322baff6932)

1. Controller.cs

Controller.cs has all the code that is needed for encryption and decryption including generation of keys and integrity check. It includes:

  - Keys Derivation
  - Hash Computation for integrity check
  - Encryption of a file
  - Decryption of a file
  - Code to benchmark the performance of key generation.

**Performance Benchmarking:**

We wanted to ensure that the Key Generation is performed with as many iterations as possible such that an attacker will have hard time predicting the key with brute-force attack. However, generating key by rehashing it for more number iterations comes with performance cost. Therefore, it is important to choose suitable number of iterations that balances security strength as well as performance of the encryption process.

For EncryptionGenie utility, we ran some benchmarking tests with multiple iterations ranging from 1000 to 1000,000 and found the following observations:

1. Iterations from 1000 to 10,000 take less than 0.2 seconds.
2. 50,000 iterations take about a second.
3. 100,000 iterations take about two seconds.

The recommended minimum iterations count is 1000 as per the standard [RFC 2898, Section 4.2](https://www.ietf.org/rfc/rfc2898.txt).

Hence, we went ahead with randomizing the iterations from 1000 to 10,000 while generating the master key with PBKDF2.

[image](https://github.com/Krishna-Paudel/EncryptionGenie/assets/52009770/f50af9a3-19c6-4299-b5bb-fa0f22e81bec)


**How to run the utility:**

On Linux:

Pre-requisites:

1. Install .Net 7.0

(https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#scripted-install)

How to execute:

1. Run EncryptionGenie-CLI.dll

On Windows:

Pre-requisites:

1. Install .Net 7.0

(https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net70)

How to execute:

1. Run EncryptionGenie-CLI.exe

**Found Bugs?**

- Reach out to Krishna Paudel \<[krpaudel@uw.edu](mailto:krpaudel@uw.edu)\> with repro steps
