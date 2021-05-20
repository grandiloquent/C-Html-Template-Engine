# C# Html Template Engine 

```html
<div>

<p>{{Name}}</p>

{{@foreach=.}}
<p>{{Firend}}</p>
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
