# Word Index
Write a program to compile an index of words from text documents. The documents are text files in a file system folder hierarchy - at least initially.

The program will be started with a root folder given on the command line:

	wordindex /folder/subfolder
	
And the index will be written to the standard output (console) like this:

	brown
		file2.txt
		subsubfolder/file1.txt
	fox
		file1.txt
		subsubfolder/file1.txt
	quick
		file1.txt
		file2.txt

The words are listed in alphabetical order. After each word the names of the files containing it are listed; the paths are given relative to the root folder. File names are indented by at least one space.

Text files are UTF-8 encoded.

Words are sequences of 3 or more case-insensitive letters (a..z, plus umlaut characters like ä,ö,ü, and ß, and characters with diacritical marks like á,ç,ô). Any non-letter character denotes the end of a word. Words do not span lines.

Certain words should be skipped, so called stop words. These words are listed in a file called _stopwords.txt_. Stop words are very common words like "the" or "how". See [here](http://www.ranks.nl/resources/stopwords.html) for an example stop word list.


## Design
There seem to be at least the following distinct aspects to a solution:

* Processing docs (domain logic)
  * Index words
  * Parse text for words
  * Don´t index stop words
* Getting docs from files (data access/files)
* Finding doc files (data access/subfolders)
* Writing the index to the standard output

The overall functionality triggered by starting the program can be captured by an interface like this:

	interface IIndexer {
		Index Build(string path);
	}
	
	class Index {
		public IEnumerable<Entry> Entries {get;}
	}
	
	class Entry {
		public string Word {get;}
		public IEnumerable<string> DocumentNames {get;}
	}

Since the output (Index) cannot be produced from the input (path) alone, there needs to be some resource/state for further data. That´s the documents. Access to them also needs to go through at least one additional interface:

	interface IDocuments {
		...
	}
	
But how should this interface look like? That´s not clear from the overall problem statement at least. It will need to evolve through the tests.

And there is more: An Index so far is only a data structure. How is it written to the standard output stream of the program? How is the path read from the command line and passed to the Indexer?

There is another aspect to the application, the UI or environmental aspect, which also needs to be captured in an interface:

	interface IConsole {
		void Run(string[] args);
	}
	
An implementation of this interface calls the Indexer which in turn calls an IDocuments implementation.

Whatever needs to be done with the environment is confined to the IConsole implementation, whatever is concerned with document access is encapsulated in an IDocuments impementation, and an IIndexer implementation is solely concerned with the domain logic of extracting words from documents and building an index from them.

Sounds like a 3-layer application:

	Console -> Indexer -> Documents
	
_With A -> B meaning A depending on/using/calling B._

## Implementation
Instead of implementing just all aspects a stepwise approach is chosen.

### Iteration 0 - Walking skeleton

### Iteration 1 (Focus: IIndexer)
* No files at all. Work on a single text doc in memory.
* No stop words

#### Iteration 1.1
* Each line contains a single word

#### Iteration 1.2
* Several words per line

### Iteration 2
* Several in-mem docs
* No stop words

### Iteration 3 (Focus: IDocuments)
* No subfolders
* Just a single text file
* No stop words

### Iteration 4 (Focus: IConsole)
* Read path from command line
* Output index to console

### Iteration 4 (Focus: IDocuments)
* No subfolders
* Multiple text files
* No stop words

### Iteration 5
* Subfolders on several levels
* No stop words

### Iteration 6 (Focus: IIndexer)
* Stop words

## Test Cases
