# Word Index
Write a program to compile an index of words in text documents. Initially the documents are text files in a folder hierarchy.

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

## Implementation
Instead of implementing just all aspects a stepwise approach is chosen.

### Iteration 1
* No files at all. Work on a single text doc in memory.
* No stop words

#### Iteration 1.1
* Each line contains a single word

#### Iteration 1.2
* Several words per line

### Iteration 2
* Several in-mem docs
* No stop words

### Iteration 3
* No subfolders
* Just a single text file
* No stop words

### Iteration 4
* No subfolders
* Multiple text files
* No stop words

### Iteration 5
* Subfolders on several levels
* No stop words

### Iteration 6
* Stop words

## Test Cases


