#!/bin/bash
# 新しい問題のフォルダを作り、雛形をコピーする
# 使い方: tools/new.sh <出典/問題名> [言語...]
#   例: tools/new.sh problems/paiza/A100_問題名 cpp
#   例: tools/new.sh problems/atcoder/ABC300_A cpp cs
#   言語を省くと cpp。すでにあるファイルは上書きしない
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/.." && pwd)"

if [ $# -lt 1 ]; then
    echo "使い方: $0 <出典/問題名> [言語...]" >&2
    exit 1
fi

DIR="$ROOT/$1"
shift
LANGS=("${@:-cpp}")

mkdir -p "$DIR"
for LANG in "${LANGS[@]}"; do
    TEMPLATE="$ROOT/templates/main.$LANG"
    if [ ! -e "$TEMPLATE" ]; then
        echo "雛形がありません: templates/main.$LANG" >&2
        exit 1
    fi
    [ -e "$DIR/main.$LANG" ] || cp "$TEMPLATE" "$DIR/main.$LANG"
done
[ -e "$DIR/input_1.txt" ] || touch "$DIR/input_1.txt"
[ -e "$DIR/Question.md" ] || touch "$DIR/Question.md"

echo "作成しました: ${DIR#$ROOT/}"
ls "$DIR"
