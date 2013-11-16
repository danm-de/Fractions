properties {
    $base_dir = Resolve-Path .
    $fraction_solution = "$base_dir\Fractions.sln"
}

Task default -depends Compile

Task Clean {
    msbuild "/property:Configuration=Release" "/t:Clean" "$fraction_solution"
}

Task Compile -depends Clean {
    msbuild "/property:Configuration=Release" "$fraction_solution"
}

Task Package -depends Compile {
    nuget pack .\Fractions\Fractions.csproj -Symbols -Prop Configuration=Release
    nuget pack .\Fractions.Json\Fractions.Json.csproj -Symbols -Prop Configuration=Release
}

Task PushPackage -depends Package {
    nuget push $base_dir\Fractions.?.?.?.?.nupkg
    nuget push $base_dir\Fractions.?.?.?.?.symbols.nupkg
    nuget push $base_dir\Fractions.Json.?.?.?.?.nupkg
    nuget push $base_dir\Fractions.Json.?.?.?.?.symbols.nupkg
}