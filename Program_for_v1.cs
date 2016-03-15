using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Baku.LibqiDotNet;

namespace TestAnimatedSay
{
    class Program
    {
        static void Main(string[] args)
        {
            //作業ディレクトリだけでなく"dlls"というフォルダのライブラリも実行中に参照できるよう設定を変更
            PathModifier.AddEnvironmentPaths(Path.Combine(Environment.CurrentDirectory, "dlls"));

            //HelloWorldの対象とするマシンのアドレスをIPとポート(ポートは通常9559)で指定
            string address = "tcp://xxx.xxx.xxx.xxx:9559";
            var session = QiSession.Create(address);


            //ALAnimatedSpeech::sayに渡す典型的なannotated text
            var text = new QiString(
                "^start(animation/Stand/Gestures/Hey_1) " + 
                "Hello, this is a typical sample sentence for animated say module, to check some autonomous motion suited for the conversation " +
                "^wait(animation/Stand/Gestures/Hey_1)"
                );

            //AnimatedSay::sayの第二引数に渡す、モーションのモードを表す単一ペアの辞書
            var config = QiMap<QiString, QiString>.Create(new[]
            {
                new KeyValuePair<QiString, QiString>(
                    new QiString("bodyLanguageMode"),
                    new QiString("contextual")
                    )
            });

            var animatedSayArgs = QiTuple.Create(text, config);
            Debug.WriteLine(animatedSayArgs.Signature);
            Debug.WriteLine(animatedSayArgs.Dump());


            var animatedSpeech = session.GetService("ALAnimatedSpeech");

            //1. CallメソッドはQiMap型のシグネチャをハンドリングできない(.NETラッパー側の不備)ので
            //     低レイヤ呼び出しのCallDirectを用いる

            //2. "(sm)"はqi Frameworkの型を表す文字列で、
            //   関数の引数に文字列("s")と、動的型("m")からなるタプル(全体を囲うカッコ)であることを示す
            //   詳細はは公式の型-文字列対応表(http://doc.aldebaran.com/libqi/api/cpp/type/signature.html)などを参照

            //3. CallDirectの戻り値は非同期形式(QiFuture)なのでGetValue()での結果取得により明示的にブロックして同期処理化
            //   (非同期で使いたければGetValue()を後で呼ぶ)
            var res = animatedSpeech
                .CallDirect("say::(sm)", animatedSayArgs.QiValue)
                .GetValue();

            //Void型が返却されるのを確認
            Debug.WriteLine(res.ContentValueKind);

        }
    }

    static class PathModifier
    {
        public static void AddEnvironmentPaths(params string[] paths)
        {
            var path = new[] { Environment.GetEnvironmentVariable("PATH") ?? "" };

            string newPath = string.Join(Path.PathSeparator.ToString(), path.Concat(paths));

            Environment.SetEnvironmentVariable("PATH", newPath);
        }
    }
}
