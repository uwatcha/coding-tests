#!/bin/bash
# C# の補完を効かせるため、csharp.csproj が読む main.cs を切り替える
# 使い方: tools/switch-cs.sh <問題フォルダ または .cs ファイル>
#   例: tools/switch-cs.sh problems/paiza/A093_コイン集め
#   引数を省くと、今いるフォルダの main.cs にする
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/.." && pwd)"
TARGET="${1:-.}"

if [ -d "$TARGET" ]; then
    FILE="$(cd "$TARGET" && pwd)/main.cs"
else
    FILE="$(cd "$(dirname "$TARGET")" && pwd)/$(basename "$TARGET")"
fi
if [ ! -e "$FILE" ]; then
    echo "ファイルがありません: $FILE" >&2
    exit 1
fi

REL="${FILE#$ROOT/}"
sed -i '' -E "s#<Compile Include=\"[^\"]+\"[[:space:]]*/>#<Compile Include=\"$REL\" />#" "$ROOT/csharp.csproj"
echo "csharp.csproj を切り替えました: $REL"
