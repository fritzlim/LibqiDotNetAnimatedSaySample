using System;
using System.Collections.Generic;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Path;

namespace AnimatedSaySample
{
    class Program
    {
        static void Main(string[] args)
        {
            PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToEntryAssembly);

            string address = "tcp://127.0.0.1:9559";
            var s = QiSession.Create(address);

            string text = "^start(animation/Stand/Gestures/Hey_1) " +
                "Hello, this is a typical sample sentence for animated say module, to check some autonomous motion suited for the conversation " +
                "^wait(animation/Stand/Gestures/Hey_1)";

            //AnimatedSay::sayの第二引数に渡す、モーションのモードを表す単一ペアの辞書
            var config = QiMap.Create(new[]
            {
                new KeyValuePair<QiString, QiString>("bodyLanguageMode", "contextual")
            });

            var animatedSpeech = s.GetService("ALAnimatedSpeech");

            var res = animatedSpeech["say"].Call(text, config);
            Console.WriteLine(res.ContentValueKind);
        }
    }
}

