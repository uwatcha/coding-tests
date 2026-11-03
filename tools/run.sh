#!/bin/bash
# 回答ファイルをコンパイルし、入力例を標準入力に渡して実行する
# 使い方: tools/run.sh <回答ファイル> [入力例の番号]
#   例: tools/run.sh problems/paiza/A093_コイン集め/main.cpp 1
#   番号を省くと、同じフォルダの input_*.txt をすべて順に実行する
# 拡張子で言語を見分ける（.cs / .cpp）。DEBUG は付けないので、ファイル内の入力の切り替えは効かない
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/.." && pwd)"

if [ $# -lt 1 ]; then
    echo "使い方: $0 <回答ファイル> [入力例の番号]" >&2
    exit 1
fi

SRC="$(cd "$(dirname "$1")" && pwd)/$(basename "$1")"
SRC_DIR="$(dirname "$SRC")"
NAME="$(basename "${SRC%.*}")"
# ビルド結果は問題フォルダに置かず .build/ の下にまとめる
OUT_DIR="$ROOT/.build/${SRC_DIR#$ROOT/}"
mkdir -p "$OUT_DIR"

case "$SRC" in
    *.cpp)
        OUT="$OUT_DIR/$NAME.out"
        clang++ -std=c++20 -O2 -Wall -I"$ROOT/include" -o "$OUT" "$SRC"
        RUN=("$OUT")
        ;;
    *.cs)
        OUT="$OUT_DIR/$NAME.exe"
        mcs -out:"$OUT" "$SRC" > /dev/null
        RUN=(mono "$OUT")
        ;;
    *)
        echo "対応していない拡張子です: $SRC" >&2
        exit 1
        ;;
esac

cd "$SRC_DIR"
if [ $# -ge 2 ]; then
    "${RUN[@]}" < "input_$2.txt"
else
    for INPUT in input_*.txt; do
        [ -e "$INPUT" ] || { echo "入力例 (input_*.txt) がありません" >&2; exit 1; }
        echo "===== $INPUT ====="
        "${RUN[@]}" < "$INPUT"
    done
fi
