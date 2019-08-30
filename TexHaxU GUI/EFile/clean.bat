@echo off
cd TexHaxU
echo Convertフォルダの中を削除します。
del .\Convert\*
echo OutDDS_Losslessフォルダの中を削除します。
del .\OutDDS_Lossless\*
rem delコマンドでフォルダ内のファイルを削除しています。
rem 最初にcdコマンドでTexHaxUフォルダへ移動させている。
pause