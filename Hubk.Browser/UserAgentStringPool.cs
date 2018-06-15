using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubk.Browser
{
    public sealed class UserAgentStringPool
    {
        public static UserAgentStringPool Default
        {
            get;
        } = new UserAgentStringPool();

        public UserAgentStringPool()
        {
            this.randomizer = new Random();
        }

        private Random randomizer;
        private readonly string[] userAgentStringCandidates = new string[] {
            "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko",
            "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36 Edge/12.0",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:25.0) Gecko/20100101 Firefox/25.0",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko",
        };

        public string GetNextUserAgentString()
        {
            return this.userAgentStringCandidates[this.randomizer.Next(0, this.userAgentStringCandidates.Length)];
        }
    }
}
