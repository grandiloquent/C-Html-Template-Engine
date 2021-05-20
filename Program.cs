using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlTemplateEngine
{
    class Program
    {
        public static List<Tuple<int, string, string>> ParseStringTemplate(string str)
        {
            var span = str.AsSpan();
            var lines = new List<Tuple<int, string, string>>();
            var offset = 0;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == '{' && span[i + 1] == '{')
                {
                    // Add anything before "{{" from "offset"
                    // "offset"----------{{

                    lines.Add(new Tuple<int, string, string>(0, span.Slice(offset, i - offset).ToString(), string.Empty));
                    i += 2;
                    offset += i - offset;
                    // Move "i" until "}}"
                    // {{------------------->"i"}}
                    while (i + 1 < span.Length && span[i] != '}' && span[i + 1] != '}')
                    {
                        i++;
                    }
                    if (i + 1 < span.Length)
                    {
                        // Parse the string between {{--------------}}

                        var key = span.Slice(offset, i - offset + 1);
                        var value = string.Empty;
                        var type = 1;
                        if (key[0] == '@')
                        {
                            type = 10;
                            var index = key.IndexOf('=');
                            value = index != -1 ? key.Slice(index + 1).ToString() : string.Empty;
                            key = index != -1 ? key.Slice(1, index - 1).Trim().ToString() : key.Slice(1).Trim();
                        }

                        lines.Add(new Tuple<int, string, string>(type, key.ToString(), value));
                        offset += i - offset + 3;
                    }
                }
            }
            if (span.Length > offset)
            {
                // Add anything after the last "}}" if have
                lines.Add(new Tuple<int, string, string>(0, span.Slice(offset, span.Length - offset).ToString(), string.Empty));
            }
            return lines;
        }
        static void Main(string[] args)
        {
            var template = "<div><p>{{Name}}</p>"
 + "{{@foreach=Friends}}"
 + "<p>{{.}}</p>"
 + "{{@end}}"
 + "</div>";

            var templates = ParseStringTemplate(template);
            var sb = new StringBuilder();
            var obj = new
            {
                Name = "Kid",
                Friends = new[] { "One", "Two", "Three" }
            };

            for (int i = 0; i < templates.Count; i++)
            {
                switch (templates[i].Item1)
                {
                    case 1:
                        {


                            sb.Append(obj.GetType().GetProperty(templates[i].Item2).GetValue(obj));
                            break;
                        }
                    case 10:
                        {
                            var index = i;
                            if (templates[i].Item2 == "foreach") // enter loop template
                            {

                                var pieces = obj.GetType().GetProperty(templates[i].Item3).GetValue(obj) as IEnumerable<object>;
                                var offset = 0;
                                foreach (var element in pieces)
                                {
                                    for (int k = i + 1; k < templates.Count; k++)
                                    {

                                        if (templates[k].Item1 == 0)
                                        {
                                            sb.Append(templates[k].Item2);
                                        }
                                        else if (templates[k].Item1 == 1)
                                        {
                                            sb.Append(element);
                                        }
                                        // exit loop template
                                        if (templates[k + 1].Item1 == 10 && templates[k + 1].Item2 == "end")
                                        {
                                            offset = k + 1;
                                            break;
                                        }
                                    }

                                }
                                // let skip the the loop template in the main render loop
                                i = offset;
                            }
                            break;
                        }
                    default:
                        {
                            sb.Append(templates[i].Item2);
                            break;
                        }
                }

            }
            Console.WriteLine(sb.ToString());

        }
    }
}
