properties {
    $base_dir = Resolve-Path .
    $sln_file = "$base_dir\Fractions.sln"
}

Task default -depends Compile

Task Clean {
    msbuild "/property:Configuration=Release" "/t:Clean" "$sln_file"
}

Task Init -depends Clean {
}

Task Compile -depends Init {
    msbuild "/property:Configuration=Release" "$sln_file"
}

Task Release -depends Compile {
}

Task Package -depends Release {
    nuget pack .\Fractions\Fractions.csproj -Prop Configuration=Release
}

