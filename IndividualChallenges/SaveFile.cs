public void SaveFile(string userInput, byte[] fileContent)
{
    // Ensure the input is a valid file name
    userInput = Path.GetFileName(userInput);
    string filePath = Path.Combine("/uploads/", userInput);

    // Validate the file path to prevent directory traversal
    string uploadsPath = Path.GetFullPath("/uploads/");
    string fullPath = Path.GetFullPath(filePath);

    if (!fullPath.StartsWith(uploadsPath))
    {
        throw new UnauthorizedAccessException("Invalid file path.");
    }

    // Save the file securely
    File.WriteAllBytes(fullPath, fileContent);
    Console.WriteLine($"File saved to {filePath}");
}
