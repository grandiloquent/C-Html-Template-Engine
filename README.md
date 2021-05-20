# C# Html Template Engine 

```
<div>

<p>{{Name}}</p>

{{@foreach=.}}
<p>{{Firend}}</p>
{{@end}}

</div>
```

Output:

```
<div><p>Kid</p><p>One</p><p>Two</p><p>Three</p></div>
```
