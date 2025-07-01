#!/bin/bash

# Generate NSwag files with the provided runtime
dotnet nswag run 

# Find all generated files in the current directory
generated_files=$(find ../src/ContactCenter.Interactions.Service/Data/ApiClients -type f -name "*.generated.cs")

# Loop through each file and remove lines containing 'StringEnumConverter'
for file in $generated_files; do
    if grep -q "\[System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))\]" "$file"; then
        sed -i '/\[System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))\]/d' "$file"
        echo "Removed 'StringEnumConverter' from $file"
    fi
done

echo "Processing complete."
