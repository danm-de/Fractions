properties {
    $base_dir = Resolve-Path .
    $sln_file = "$base_dir\Fractions.sln"
}

Task default -depends Compile

Task Clean {
    msbuild "/property:Configuration=Release" "/t:Clean" "$sln_file"
}

Task Compile -depends Clean {
    msbuild "/property:Configuration=Release" "$sln_file"
}

Task Package -depends Compile {
    nuget pack .\Fractions\Fractions.csproj -Symbols -Prop Configuration=Release
}

