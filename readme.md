![Icon](https://raw.github.com/Fody/Fody/master/package_icon.png)

## A working sample for each  [Fody](https://github.com/Fody/Home/)Addin


## Notes

To update all packages

```
Get-Project -All | % { Get-Package -ProjectName $_.ProjectName | Update-Package -ProjectName $_.ProjectName}
```
