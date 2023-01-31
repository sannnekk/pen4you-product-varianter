namespace ProductVarianter.Helpers
{
    public static class IDResolver
    {
        /** 
         * Copied from Stackoverflow 
         * [https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string]
         *
         */
        public static string Resolve(string seed)
        {
            var md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(seed);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}