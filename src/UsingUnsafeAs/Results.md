.NET 6

|            Method |      Mean |     Error |    StdDev | Allocated |
|------------------ |----------:|----------:|----------:|----------:|
|   CastUsingCSharp | 0.2905 ns | 0.0397 ns | 0.0372 ns |         - |
| CastUsingUnsafeAs | 0.0000 ns | 0.0000 ns | 0.0000 ns |         - |

## .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingCSharp()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rax,rdx
       test      rax,rax
       je        short M00_L00
       mov       rcx,offset MT_UsingUnsafeAs.TargetType
       cmp       [rax],rcx
       jne       short M00_L01
M00_L00:
       add       rsp,28
       ret
M00_L01:
       call      CORINFO_HELP_CHKCASTCLASS_SPECIAL
       int       3
; Total bytes of code 42
```

## .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingUnsafeAs()
       mov       rax,[rcx+8]
       ret
; Total bytes of code 5
```


.NET 7

|            Method |      Mean |     Error |    StdDev | Allocated |
|------------------ |----------:|----------:|----------:|----------:|
|   CastUsingCSharp | 1.2280 ns | 0.0521 ns | 0.0488 ns |         - |
| CastUsingUnsafeAs | 0.9835 ns | 0.0618 ns | 0.0578 ns |         - |

## .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingCSharp()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rax,rdx
       test      rax,rax
       je        short M00_L00
       mov       rcx,offset MT_UsingUnsafeAs.TargetType
       cmp       [rax],rcx
       jne       short M00_L01
M00_L00:
       add       rsp,28
       ret
M00_L01:
       call      qword ptr [7FF978FDB8B8]
       int       3
; Total bytes of code 43
```

## .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingUnsafeAs()
       mov       rax,[rcx+8]
       ret
; Total bytes of code 5
```