﻿using System.Text;

namespace Plugin.Toolkit.Security
{
    public class SecurityToolkitMD5
    {
        /// <summary>
        /// Generates a MD5 hash for the provided string value. If no value is provided, 
        /// the current UTC date and time is used. The hash is returned as a hexadecimal string.
        /// </summary>
        /// <param name="value">The string value to be hashed. Defaults to an empty string.</param>
        /// <returns>A hexadecimal string representing the MD5 hash of the input value.</returns>
        public string Hash(string value = "")
        {
            if (value == "")
            {
                value = DateTime.UtcNow.ToString();
            }
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
