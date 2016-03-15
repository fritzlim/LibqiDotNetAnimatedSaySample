# LibqiDotNetAnimatedSaySample


Baku
2016/Mar/15

1. About
2. How to use
3. License
4. Contact


## About / How to use
本レポジトリはAldebaran社のロボットが利用している通信フレームワーク`libqi`の.NETラッパーである[`Baku.LibqiDotNet`](https://github.com/malaybaku/BakuLibQiDotNet)の利用例を紹介するサンプルです。

具体的にはモーションつき発話を行う[ALAnimatedSpeech::say](http://doc.aldebaran.com/2-1/naoqi/audio/alanimatedspeech-api.html#ALAnimatedSpeechProxy::say__ssCR)を.NETから呼び出す例を紹介しています。

とある方から`Baku.LibqiDotNet`(NuGetパッケージのver1.0.1)の動作不具合に関するご質問を頂いたため、回答というか回避策の紹介を目的に公開しました。


## How to use

`Baku.LibqiDotNet`の使い方が分かっている前提で作ってるレポジトリであるため、最低限のサンプルコードだけを配置しています。使用しているBaku.LibqiDotNetのバージョンに応じて使い分けて下さい。

- ver1.0.1/1.0.0を使ってる場合: `Program_for_v1.cs`がサンプルです。回避策が具体的に載ってます。
- ver2.0.0以降を使ってる場合: `Program_for_v2.cs`がサンプルです。回避策が不要になってるのでコードはかなり小さいです。



## License
`Baku.LibqiDotNet`のライセンス(MIT License)に従います。

## Contact

- [Blog](http://www.baku-dreameater.net/)
- [Twitter](https://twitter.com/baku_dreameater)

