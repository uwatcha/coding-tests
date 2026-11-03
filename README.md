# コーディングテスト用コマンド集

## ディレクトリ構成

```
problems/     問題（出題先ごとにフォルダを分ける）
  paiza/        paiza の問題（A093_問題名 など）
  atcoder/      AtCoder の問題（ABC300_A など）
  leetcode/     LeetCode の問題（0001_two-sum など）
  gemini/       Gemini に作らせた問題
  sansan/       Sansan の問題
templates/    新しい問題の雛形（main.cpp, main.cs）
snippets/     使い回しの部品
include/      C++ 用の自作 bits/stdc++.h
tools/        スクリプト
.build/       tools/run.sh と C++ のデバッグのビルド結果（消してよい）
```

1つの問題のフォルダには `Question.md`・`input_n.txt`・`main.<拡張子>` を置く。同じ問題を別の言語で解いたら、同じフォルダに並べる。

## 新しい問題を始める

```bash
tools/new.sh problems/paiza/A100_問題名          # C++ の雛形を作る
tools/new.sh problems/atcoder/ABC300_A cpp cs    # C++ と C# の両方を作る
```

## 実行（コンパイル込み）

```bash
tools/run.sh problems/paiza/A093_コイン集め/main.cs 1    # input_1.txt で実行
tools/run.sh problems/paiza/A093_コイン集め/main.cpp     # input_*.txt をすべて実行
```

`DEBUG` を付けずにコンパイルするので、ファイル内の `#if DEBUG` / `#ifdef DEBUG` の入力の切り替えは効かない。

## デバッグ（VSCode）

回答ファイルを開き、「実行とデバッグ」で次の設定を選んで F5 を押す。

- C#: `Debug current C# file with Mono`
- C++: `Debug current C++ file with LLDB`（CodeLLDB 拡張が必要）

どちらも `DEBUG` を付けてコンパイルするので、ファイル内で指定した `input_n.txt` を読む。

## 手でコンパイルする場合

### C#

```bash
mcs main.cs
mono main.exe < input_n.txt
```

### C++

```bash
clang++ -std=c++20 -O2 -I<ルート>/include -o main.out main.cpp
./main.out < input_n.txt
```

Mac の `g++` の実体は Apple clang で、`bits/stdc++.h` が無い。そのため `include/bits/stdc++.h` を自作し、`-I` で読み込む。

## C# の補完の対象を切り替える

`csharp.csproj` は1つの `main.cs` だけを読む設定にしている。補完を効かせたいファイルに切り替える。

```bash
tools/switch-cs.sh problems/paiza/A093_コイン集め
```

## C++ の補完

ルートの `compile_flags.txt` を clangd が読む。clangd 拡張（`llvm-vs-code-extensions.vscode-clangd`）を入れると、`bits/stdc++.h` を含めて補完が効く。
