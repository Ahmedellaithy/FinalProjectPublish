namespace FinalProject.Core.Downloads;

public static class Images
{
    public static async Task<byte[]> DownloadImageAsync(string imageUrl)
    {
        using (HttpClient client = new HttpClient()) // Create an HTTP client
        {
            try
            {
                return await client.GetByteArrayAsync(imageUrl); // Fetch image as byte array
            }
            catch (Exception ex)
            {
                throw new Exception("Error downloading the image: " + ex.Message);
            }
        }
    }
}