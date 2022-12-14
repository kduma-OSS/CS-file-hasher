# CS-file-hasher

MD5 and SHA1 file hash calculator and checker

### `hasher` tool

Main tool containing two others.

```./hasher check [--help] [--version] file [file ...]```

```./hasher hash [--help] [--version] [-t|--type {both,md5,sha1}] file [file ...]```

```
check      Verify hashes for given file

hash       Generate hashes for given file

help       Display more information on a specific command.

version    Display version information.
```

### `hash` tool

Extracted only hashing portion from `hashing` tool.

```./hash [--help] [--version] [-t|--type {both,md5,sha1}] file [file ...]```

```
-t, --type        (Default: Both) Type of calculated hash (both,md5,sha1)

--help            Display this help screen.

--version         Display version information.

files (pos. 0)    Required. Files to generate hashes for
```

### `check` tool

Extracted only checking portion from `hashing` tool.

```./check [--help] [--version] file [file ...]```

```
--help            Display this help screen.

--version         Display version information.

files (pos. 0)    Required. Hash files to check
```
