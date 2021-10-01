# ktyl's ktools

ktools is a general-purpose set of scripts that can be used in Unity projects to manage project architecture and runtime performance.

## Features

### Scriptable Object-based Events and Variables

Implementations of events and variables as outlined in [this Unity blog post](https://unity.com/how-to/architect-game-code-scriptable-objects). Both include additional features, such as in-editor pinging of event listeners and a generic base class for variables, allowing any serializable type to be added with ease.

### Pooling

A generic `IPool<T>` interface and a stack-based implementation avoid deallocating objects with short lifetimes.

## Getting Started

1.  Create or open a Unity project.
2.  Open Window -> Package Manager.
3.  Click the '+' icon in the top left corner, select 'Add Package from git URL' and input the URL to the ktools repository: https://github.com/ktyldev/ktools.git.
4.  Enjoy!