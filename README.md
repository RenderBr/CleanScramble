# CleanScramble

CleanScramble is a lightweight scrambling framework built with SOLID and clean code principles. It provides a flexible and extensible solution for scrambling strings using various algorithm implementations. Note: This README was written by AI after being fed the codebase, however none of the code was AI generated, and was written by me.

## Table of Contents

- [Features](#features)
- [Project Structure](#project-structure)
- [Use Cases and Motivation](#use-cases-and-motivation)
- [Getting Started](#getting-started)
- [Usage Example](#usage-example)
- [SOLID and Clean Code](#solid-and-clean-code)
- [Testing](#testing)
- [Contributing](#contributing)

## Features

- **SOLID Principles:** The design leverages dependency inversion, interface segregation, and other SOLID principles to promote extensibility and maintainability.
- **Extensible Algorithms:** Easily plug in new scrambling algorithms by implementing the `IAlgorithm<T>` interface.
- **Robust Input Handling:** Handles edge cases such as `null`, empty strings, and strings with special characters.
- **Test Coverage:** Unit tests using xUnit ensure that the core functionality behaves as expected.

## Project Structure

- **CleanScramble.Models.Helpers**  
  Contains the core interfaces and classes for scrambling, including:
  - `IScrambler<T>`: Defines the contract for scrambling objects.
  - `WordScrambler`: A concrete implementation that scrambles strings using an injected algorithm.

- **CleanScramble.Models.Algorithms**  
  Provides the scrambling algorithm infrastructure:
  - `IAlgorithm<T>`: A generic interface for scrambling algorithms.
  - `RandomWordScramblingAlgorithm`: A sample algorithm that scrambles strings randomly.

- **CleanScramble.Models.Algorithms.Logic**  
  Houses auxiliary classes for algorithm logic:
  - `IRandomizer`: Interface to abstract randomization logic.
  - `Randomizer`: A concrete randomizer implementation.

- **CleanScramble.Tests**  
  Contains unit tests (using xUnit) that validate the behavior of the scrambling functionality.

Below is an additional section you can add to your README that explains the use cases for CleanScramble and your motivation for creating it:

---

## Use Cases and Motivation

CleanScramble was created with two primary goals in mind:

1. **Practical Use Cases:**
   - **Educational Tools:**  
     Use CleanScramble as an example for learning text transformation techniques and algorithm design. It’s a simple framework that demonstrates how to implement and swap different algorithms seamlessly.
   - **Games and Puzzles:**  
     Generate scrambled words for word games, puzzles, quizzes, or any application that needs randomization of text.
   - **Data Obfuscation:**  
     While not a security solution, it can serve to mildly obfuscate textual data for low-risk scenarios.
   - **Prototyping:**  
     Quickly test and iterate on new scrambling algorithms without the overhead of a larger, more complex codebase.

2. **Motivation Behind the Project:**
   - **Demonstrating SOLID Principles:**  
     CleanScramble was designed to adhere strictly to SOLID and clean code principles. It serves as a practical example of how to write maintainable, extensible, and testable code.
   - **Showcasing Clean Code Practices:**  
     The project exemplifies best practices in structuring code, handling edge cases, and writing comprehensive unit tests. It is intended to be a reference or starting point for developers interested in these methodologies.
   - **Open-Source Learning:**  
     By making CleanScramble available to the community, the goal is to encourage learning and improvement through collaboration. Developers can study, use, and contribute to a project that embodies modern software design principles.

---

You can integrate this section into your README to provide visitors with clear insights into what CleanScramble can be used for and the reasoning behind its creation.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- An IDE of your choice (e.g., [Rider](https://www.jetbrains.com/rider/), Visual Studio, or VS Code)

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

## Usage Example

Here’s a simple example demonstrating how to scramble a word:

```csharp
using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Helpers;

class Program
{
    static void Main(string[] args)
    {
        var algorithm = new RandomWordScramblingAlgorithm(new Randomizer());
        var scrambler = new WordScrambler(algorithm);
        
        string originalWord = "example";
        string scrambledWord = scrambler.Scramble(originalWord);
        
        Console.WriteLine($"Original: {originalWord}");
        Console.WriteLine($"Scrambled: {scrambledWord}");
    }
}
```

## SOLID and Clean Code

CleanScramble is designed with the following principles in mind:

- **Single Responsibility Principle (SRP):**  
  Each class has a single responsibility. For example, `WordScrambler` is only responsible for managing the scrambling process, while the scrambling logic itself is encapsulated in algorithms that implement `IAlgorithm<string>`.

- **Open/Closed Principle (OCP):**  
  The system is open for extension but closed for modification. New scrambling algorithms can be added by simply implementing `IAlgorithm<string>` without changing the existing code.

- **Liskov Substitution Principle (LSP):**  
  Classes and interfaces are designed so that derived classes (or alternative implementations) can be substituted without affecting the overall correctness of the program.

- **Interface Segregation Principle (ISP):**  
  Interfaces are kept small and focused. For example, `IScrambler<T>`, `IAlgorithm<T>`, and `IRandomizer` expose only the necessary methods.

- **Dependency Inversion Principle (DIP):**  
  High-level modules (e.g., `WordScrambler`) depend on abstractions (interfaces) rather than concrete implementations, which increases testability and flexibility.

## Testing

Unit tests are written using xUnit. You can run the tests using the following command:

```bash
dotnet test
```

In Rider, open the Unit Tests window (View → Tool Windows → Unit Tests) to run and view test output, including logs provided via `ITestOutputHelper`.

Below is an example of some of the tests included in the project:

```csharp
using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Helpers;
using Xunit.Abstractions;

namespace CleanScramble.Tests;

public class WordScramblerTests(ITestOutputHelper testOutputHelper)
{
    private readonly WordScrambler _wordScrambler = new(new RandomWordScramblingAlgorithm(new Randomizer()));

    [Fact]
    public void GetScramble_UseNullString()
    {
        Assert.Throws<ArgumentNullException>(() => _wordScrambler.Scramble(null));
    }

    [Fact]
    public void GetScramble_UseEmptyString()
    {
        var emptyString = string.Empty;

        var result = _wordScrambler.Scramble(emptyString);
        Assert.Equal(emptyString, result);
    }

    [Fact]
    public void GetScramble_UseSpecialCharacter()
    {
        var specialCharacter = "\n";

        var result = _wordScrambler.Scramble(specialCharacter);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.Equal(specialCharacter, result);
    }

    [Fact]
    public void GetScramble_UseValidWordWithSpecialCharacter()
    {
        var word = "dog\n";

        var result = _wordScrambler.Scramble(word);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.True(word != result);
    }

    [Fact]
    public void GetScramble_UseValidWord()
    {
        var word = "average";

        var result = _wordScrambler.Scramble(word);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.True(word != result);
    }
}
```

## Contributing

Contributions are welcome! If you have suggestions or improvements, please fork the repository and submit a pull request. Be sure to update tests as appropriate when making changes.
