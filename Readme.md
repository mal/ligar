# Ligar

A Windows binary designed specifically to make replacing `notepad.exe` using Image File Execution Options less painful.

## Problem

As anyone that has tried using [this method](http://www.cult-of-tech.net/2011/10/replacing-notepad-with-notepad-using-image-file-execution-options/) to replace `notepad.exe` knows, there is a hidden pitfall in the form of passing arguments. Typically arguments passed to `nodepad.exe` are not quoted, which can leave just about any modern program baffled. One solution is to manually join arguments with a space to recreate the original filename; but consider:

~~~
C:\Users\mal\Documents\tricksy     spaces.txt
~~~

The result here would be to try and open `tricksy spaces.txt` which at best isn't going to exist, and at worst **will open the wrong file**!

## Download

[Win7 x64](http://mal.github.io/ligar/ligar.exe)

## Install

Run `Install.vbs` (needs priviledge elevation to edit registry):
~~~
Microsoft (R) Windows Script Host Version 5.8
Copyright (C) Microsoft Corporation. All rights reserved.

liger.exe: C:\path\to\liger.exe
handler: C:\path\to\gvim.exe
options: -c "set gfn=lucida_console:h10 go=aegmr shortmess+=I" -c "startinsert"

Registry key written.
~~~

_In this example we've replaced `notepad.exe` with `gvim.exe` and overridden a few options to more closely resemble `notepad.exe`._

## Usage

~~~
ligar.exe <handler> [options] --- <original> [file]

  handler     The application want to launch instead of original
  options     Arbitrary options to forward to handler
  original    The application that got intercepted
  file        Unquoted file path to salvage
~~~

_N.B. In reality, you'll never need to pass `original` or `file` as Windows will take care of them for you._

## Contributing

The functional goal of this project has already been met, however this is my first C# app, and likely has a bug or two lurking in edge cases. If you feel so inclined, patches to address any such issues are welcome. Bare in mind that we're aiming for a tiny and quick binary, so failing fast is far preferable to verbose error handling and warnings.

## License

Copyright (C) 2013 Mal Graty &lt;mal.graty@googlemail.com&gt;

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
