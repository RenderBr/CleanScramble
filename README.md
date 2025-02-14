
---

# CleanScramble

CleanScramble is a lightweight and extensible text scrambling framework built with SOLID and clean code principles. It allows you to transform strings using a variety of scrambling algorithms, ranging from classic ciphers like Caesar and ROT13 to creative techniques like Rail Fence and Binary conversion. The framework is designed for maintainability, flexibility, and ease of testing.

> **Note:** While this README was generated with assistance from an AI tool, the codebase itself was entirely written by me, Average! You can probably tell because it's becoming kind of a mess 😅

---

## Table of Contents

- [Features](#features)
- [Project Structure](#project-structure)
- [Use Cases and Motivation](#use-cases-and-motivation)
- [Getting Started](#getting-started)
- [Usage Examples](#usage-examples)
- [SOLID and Clean Code](#solid-and-clean-code)
- [Testing](#testing)
- [Contributing](#contributing)

---

## Features

- **Modular and Extensible:**  
  Easily add or swap scrambling algorithms by implementing the `IAlgorithm<T>` interface.
  
- **Multiple Algorithms:**  
  Includes a variety of algorithms such as:
  - **Binary Conversion:** Converts text to its binary representation.
  - **Caesar Cipher & ROT13:** Classic letter shifting techniques.
  - **Rail Fence Cipher:** Rearranges letters in a zig-zag pattern.
  - **Random Word Shuffling:** Randomly shuffles the characters in a string.
  - **Repeater:** Randomly repeats characters to create an obfuscated text.

- **SOLID Principles:**  
  The design adheres to SOLID and clean code principles, ensuring high maintainability and ease of extension.

- **Robust Input Handling:**  
  Handles edge cases like `null`, empty strings, and strings with only whitespace or special characters.

- **Extensive Testing:**  
  Comprehensive unit tests (using xUnit) ensure that all core functionalities perform as expected.

---

## Project Structure

- **CleanScramble.Models.Algorithms**  
  Contains the core scrambling algorithm implementations:
  - `BinaryConversion`, `CaesarCipher`, `Rot13`, `RailFenceCipher`, `RandomWordShuffler`, and `Repeater`.
  - All algorithms implement the generic `IAlgorithm<string>` interface.

- **CleanScramble.Models.Algorithms.Logic**  
  Provides supporting logic and abstractions:
  - `IRandomizer` and its implementation `Randomizer` abstract the randomization process used in several algorithms.

- **CleanScramble.Models.Factories**  
  Includes helper classes like `ScrambleRequestFactory` for creating transform requests with custom settings.

- **CleanScramble.Models.Helpers**  
  Contains transformers such as:
  - `WordScrambler`: Transforms text based on the provided algorithm while ensuring that the output is different from the input when required.
  - `PlainTextConverter`: A simpler transformer for direct algorithm execution.

- **CleanScramble.Models.Requests & CleanScramble.Models.Settings**  
  Define the request and settings contracts that allow for flexible algorithm configuration and transformation options.

- **CleanScramble.Tests**  
  Holds xUnit tests that validate the behavior and correctness of the framework.

- **AlgorithmProvider**  
  A singleton that centralizes access to the available algorithms.

---

## Use Cases and Motivation

CleanScramble was created with several practical applications in mind:

1. **Educational Tools:**  
   Demonstrate text transformation techniques and algorithm design using a clear and modular codebase.

2. **Games and Puzzles:**  
   Easily generate scrambled words or phrases for use in puzzles, quizzes, or word games.

3. **Data Obfuscation:**  
   While not intended for high-security applications, it can provide light obfuscation for textual data.

4. **Rapid Prototyping:**  
   Quickly test new scrambling algorithms or ideas without the overhead of a large, complex system.

### Motivation Behind the Project

- **SOLID & Clean Code:**  
  The project is a showcase for applying SOLID principles and writing maintainable, testable, and extensible code.
  
- **Learning and Collaboration:**  
  Designed to be a reference project for developers looking to understand modern software design and contribute to an open-source codebase.

---

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A compatible IDE (e.g., [Rider](https://www.jetbrains.com/rider/), Visual Studio, or VS Code)

### Installation

Clone the repository:

```bash
git clone https://github.com/RenderBr/CleanScramble.git
cd CleanScramble
```

Build the solution:

```bash
dotnet build
```

---

## Usage Examples

### Example 1: Basic Transformation with Caesar Cipher

This example demonstrates how to scramble a word using the Caesar Cipher algorithm from the `AlgorithmProvider`:

```csharp
using System;
using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Factories;
using CleanScramble.Models.Helpers;
using CleanScramble.Models.Requests;

class Program
{
    static void Main(string[] args)
    {
        // Select the CaesarCipher algorithm from the provider
        var algorithm = AlgorithmProvider.Instance.CaesarCipher;
        
        // Create a transformation request using the factory
        var request = ScrambleRequestFactory.UseCustomScramblerAlgorithm("example", algorithm);
        
        // Transform the input using WordScrambler
        ITransformer<string> scrambler = new WordScrambler();
        string scrambledWord = scrambler.Transform(request);
        
        Console.WriteLine($"Original: example");
        Console.WriteLine($"Scrambled (Caesar Cipher): {scrambledWord}");
    }
}
```

### Example 2: Using Rail Fence Cipher with Custom Settings

This example shows how to use the Rail Fence Cipher with a custom number of rails:

```csharp
using System;
using CleanScramble.Models.Factories;
using CleanScramble.Models.Helpers;
using CleanScramble.Models.Requests;

class Program
{
    static void Main(string[] args)
    {
        // Create a Rail Fence Cipher transformation request with 5 rails
        var request = ScrambleRequestFactory.CreateRailFenceCyper("This is a secret message.", 5);
        
        // Transform the input using WordScrambler
        ITransformer<string> scrambler = new WordScrambler();
        string scrambledText = scrambler.Transform(request);
        
        Console.WriteLine("Original: This is a secret message.");
        Console.WriteLine("Scrambled (Rail Fence Cipher):");
        Console.WriteLine(scrambledText);
    }
}
```

### Example 3: Converting Text to Binary Representation

This example uses the Binary Conversion algorithm to convert a string into its binary form:

```csharp
using System;
using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Factories;
using CleanScramble.Models.Helpers;
using CleanScramble.Models.Requests;

class Program
{
    static void Main(string[] args)
    {
        // Select the BinaryConversion algorithm from the provider
        var algorithm = AlgorithmProvider.Instance.BinaryConversion;
        
        // Create a transformation request using the factory
        var request = ScrambleRequestFactory.UseCustomScramblerAlgorithm("Hello", algorithm);
        
        // Transform the input using PlainTextConverter (which directly applies the algorithm)
        ITransformer<string> converter = new PlainTextConverter();
        string binaryOutput = converter.Transform(request);
        
        Console.WriteLine($"Original: Hello");
        Console.WriteLine($"Binary Conversion: {binaryOutput}");
    }
}
```

### Example 4: Random Word Shuffling

This example uses the Random Word Shuffler to scramble a string by randomly rearranging its characters:

```csharp
using System;
using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Factories;
using CleanScramble.Models.Helpers;
using CleanScramble.Models.Requests;

class Program
{
    static void Main(string[] args)
    {
        // Select the RandomWordShuffler algorithm from the provider
        var algorithm = AlgorithmProvider.Instance.BasicWordShuffler;
        
        // Create a transformation request using the factory
        var request = ScrambleRequestFactory.UseCustomScramblerAlgorithm("randomize", algorithm);
        
        // Transform the input using WordScrambler
        ITransformer<string> scrambler = new WordScrambler();
        string shuffledWord = scrambler.Transform(request);
        
        Console.WriteLine($"Original: randomize");
        Console.WriteLine($"Scrambled (Random Word Shuffling): {shuffledWord}");
    }
}
```

### Example 5: Repeating Characters for Obfuscation

This example demonstrates using the Repeater algorithm to randomly repeat characters:

```csharp
using System;
using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Factories;
using CleanScramble.Models.Helpers;
using CleanScramble.Models.Requests;

class Program
{
    static void Main(string[] args)
    {
        // Select the Repeater algorithm from the provider
        var algorithm = AlgorithmProvider.Instance.Repeater;
        
        // Create a transformation request using the factory
        var request = ScrambleRequestFactory.UseCustomScramblerAlgorithm("obfuscate", algorithm);
        
        // Transform the input using WordScrambler
        ITransformer<string> scrambler = new WordScrambler();
        string repeatedOutput = scrambler.Transform(request);
        
        Console.WriteLine($"Original: obfuscate");
        Console.WriteLine($"Scrambled (Repeater): {repeatedOutput}");
    }
}
```

---

## SOLID and Clean Code

CleanScramble is designed with a strong emphasis on SOLID principles:

- **Single Responsibility Principle (SRP):**  
  Each class focuses on one specific aspect of the transformation process.

- **Open/Closed Principle (OCP):**  
  The framework is open for extension through new algorithm implementations while remaining closed to modifications of existing code.

- **Liskov Substitution Principle (LSP):**  
  New algorithms can replace existing ones without impacting the functionality of the system.

- **Interface Segregation Principle (ISP):**  
  The use of small, focused interfaces (e.g., `IAlgorithm<T>`, `IRandomizer`, etc.) ensures that classes only depend on the methods they actually use.

- **Dependency Inversion Principle (DIP):**  
  High-level components, such as transformers, rely on abstractions rather than concrete implementations, making the framework flexible and testable.

---

## Testing

Unit tests are written using xUnit. To run the tests, execute:

```bash
dotnet test
```

The tests cover various scenarios, including edge cases (null, empty strings, whitespace, special characters) and valid input transformations. The test suite logs output (using `ITestOutputHelper`) for easier debugging and verification of results.

---

## Contributing

Contributions are welcome! If you have ideas for new algorithms, improvements, or bug fixes, please follow these steps:

1. Fork the repository.
2. Create a new branch for your changes.
3. Write clear and concise code with accompanying tests.
4. Submit a pull request with a detailed description of your changes.

Be sure to follow the existing code style and update tests as needed.

---

Happy Scrambling!
