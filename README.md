# C# Html Template Engine & String Template Engine

```html
<div>

<p>{{Name}}</p>

{{@foreach=Friends}}
<p>{{.}}</p>
{{@end}}

</div>
```

```csharp
            var obj = new
            {
                Name = "Kid",
                Friends = new[] { "One", "Two", "Three" }
            };
```

Output:

```html
<div><p>Kid</p><p>One</p><p>Two</p><p>Three</p></div>
```

```json
 ["abort", "canplay", "canplaythrough", "durationchange", "emptied", "ended", "error", "loadeddata",
            "loadedmetadata", "loadstart", "pause", "play", "playing", "progress", "ratechange", "seeked ", "seeking",
            "stalled", "suspend", "timeupdate", "volumechange", "waiting", "loading"
        ]
```

```
{{@foreach=}}
 case '{{.}}': {

                       console.log("{{.}}");
                        break;

                    }
{{@end}}
```

Output:

```js

 case 'abort': {

                       console.log("abort");
                        break;

                    }

 case 'canplay': {

                       console.log("canplay");
                        break;

                    }

 case 'canplaythrough': {

                       console.log("canplaythrough");
                        break;

                    }

 case 'durationchange': {

                       console.log("durationchange");
                        break;

                    }

 case 'emptied': {

                       console.log("emptied");
                        break;

                    }

 case 'ended': {

                       console.log("ended");
                        break;

                    }

 case 'error': {

                       console.log("error");
                        break;

                    }

 case 'loadeddata': {

                       console.log("loadeddata");
                        break;

                    }

 case 'loadedmetadata': {

                       console.log("loadedmetadata");
                        break;

                    }

 case 'loadstart': {

                       console.log("loadstart");
                        break;

                    }

 case 'pause': {

                       console.log("pause");
                        break;

                    }

 case 'play': {

                       console.log("play");
                        break;

                    }

 case 'playing': {

                       console.log("playing");
                        break;

                    }

 case 'progress': {

                       console.log("progress");
                        break;

                    }

 case 'ratechange': {

                       console.log("ratechange");
                        break;

                    }

 case 'seeked ': {

                       console.log("seeked ");
                        break;

                    }

 case 'seeking': {

                       console.log("seeking");
                        break;

                    }

 case 'stalled': {

                       console.log("stalled");
                        break;

                    }

 case 'suspend': {

                       console.log("suspend");
                        break;

                    }

 case 'timeupdate': {

                       console.log("timeupdate");
                        break;

                    }

 case 'volumechange': {

                       console.log("volumechange");
                        break;

                    }

 case 'waiting': {

                       console.log("waiting");
                        break;

                    }

 case 'loading': {

                       console.log("loading");
                        break;

                    }

```