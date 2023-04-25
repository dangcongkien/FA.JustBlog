using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.DataContext
{
    public static class JustBlogInitializer
    {
        public static void SeedData(this ModelBuilder builder)
        {
            // Add data into Categories
            builder.Entity<Categories>().HasData(
                new Categories
                {
                    CategoryId = 1,
                    Name = "Tech",
                    UrlSlug = "tech",
                    Description = "Posts related to technology"
                },

                new Categories
                {
                    CategoryId = 2,
                    Name = "Food",
                    UrlSlug = "tech",
                    Description = "Posts related to health and wellness"
                },

                new Categories
                {
                    CategoryId = 3,
                    Name = "Travel",
                    UrlSlug = "tech",
                    Description = "Posts related to movies, music, and other forms of entertainment"
                },
                new Categories
                {
                    CategoryId = 4,
                    Name = "Personal Development",
                    UrlSlug = "personal-development",
                    Description = "A blog that focuses on self-improvement, motivation, and success strategies."
                },

                new Categories
                {
                    CategoryId = 5,
                    Name = "Lifestyle",
                    UrlSlug = "lifestyle",
                    Description = "A blog that covers topics such as fashion, travel, food, and relationships."
                },

                new Categories
                {
                    CategoryId = 6,
                    Name = "Parenting",
                    UrlSlug = "parenting",
                    Description = "A blog that provides tips, advice, and stories on raising children, from infancy to teenage years."
                },
                new Categories
                {
                    CategoryId = 7,
                    Name = "Education",
                    UrlSlug = "education",
                    Description = "A blog that covers topics such as teaching strategies, educational resources, and trends in education."
                },

                new Categories
                {
                    CategoryId = 8,
                    Name = "Business and Finance",
                    UrlSlug = "business-and-finance",
                    Description = "A blog that provides insights, tips, and news on entrepreneurship, finance, and management."
                },

                new Categories
                {
                    CategoryId = 9,
                    Name = "Arts and Culture",
                    UrlSlug = "arts-and-culture",
                    Description = "A blog that covers topics such as music, movies, art, literature, and other forms of cultural expression."
                },

                new Categories
                {
                    CategoryId = 10,
                    Name = "Health and Wellness",
                    UrlSlug = "health-and-wellness",
                    Description = "A blog that discusses topics such as fitness, nutrition, mental health, and natural remedies."
                }
            );

            // Add data into Posts
            builder.Entity<Posts>().HasData(
                new Posts
                {
                    PostId = 1,
                    Title = "US toughens restrictions on Chinese tech firms linked to military",
                    ShortDescription = "As part of Thursday’s announcement, the US also said it was removing some Chinese companies from a so-called “watch list” after the firms were deemed to not pose a risk to US national security.",
                    PostContent = "Washington\r\nCNN\r\n — \r\nThe United States added a major Chinese chipmaker and dozens of other Chinese companies to a trade blacklist Thursday as it works to restrict Beijing’s high-tech and artificial intelligence industries.\r\n\r\nAdding chipmaker YMTC to the list of restricted companies escalates Washington’s attempts to crack down on companies that could be used to bolster China’s military.\r\n\r\nThe restrictions would ban US companies from shipping goods to some of the blacklisted companies without first obtaining a special license. Other companies will be further restricted from buying any product made using American technology.\r\n\r\nThe US has been working steadily to limit what business US companies can do with Chinese firms that the US suspects of aiding China’s military or its human rights abuses.\r\n\r\nIn October, the US imposed sweeping new curbs designed to curtail China’s access to technology critical to the manufacturing and operations of its military power. The US alleges the companies added to the lists pose a national security threat, including by helping power artificial intelligence technology and hypersonic missiles\r\n\r\nThe latest moves come weeks after President Joe Biden met for the first time face-to-face with Chinese President Xi Jinping. The talks were intended as a starting-off point for greater communication between the two world superpowers.",
                    UrlSlug = "us-toughens-restrictions-on-chinese-tech-firms-linked-to-military",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 3,
                    ViewCount = 100,
                    RateCount = 10,
                    TotalRate = 20,
                },

                new Posts
                {
                    PostId = 2,
                    Title = "Senate passes legislation to ban TikTok from US government devices",
                    ShortDescription = "\r\nCNN\r\n — \r\nThe Senate passed legislation Wednesday evening to ban TikTok from US government devices, in a move designed to limit perceived information-security risks stemming from the social media app.",
                    PostContent = "The latest legislative action comes as TikTok and the US government have been negotiating a deal that may allow the app to keep serving US users. There have been years of closed-door talks between TikTok and the Committee on Foreign Investment in the United States, as well as recent reports of delays in the negotiations.\r\n\r\nSome lawmakers have expressed frustration with an apparent lack of progress in those talks. Following Wednesday’s vote, Virginia Democratic Sen. Mark Warner, a vocal critic of TikTok, said of the process: “My patience is running out.”\r\n\r\nOn Tuesday, US lawmakers led by Florida Republican Sen. Marco Rubio introduced a bill to ban TikTok in the United States more generally, along with other apps based in, or under the “substantial influence” of, countries that are considered foreign adversaries, including China, Russia, Iran, North Korea, Cuba and Venezuela. In introducing the bill, Rubio also indicated some frustration, saying that the federal government “has yet to take a single meaningful action” on the matter.\r\n\r\nBut several senators, including Warner and Hawley, have stopped short of endorsing Rubio’s proposal. On Thursday, Hawley said he would be “fine” if the US government and TikTok reached a deal to safeguard US users’ data. “But if they don’t do that … then I think we’re going to have to look at more stringent measures,” Hawley said.",
                    UrlSlug = "senate-passes-legislation-to-ban-tiktok-from-us-government-devices",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 2,
                    ViewCount = 200,
                    RateCount = 7,
                    TotalRate = 28,
                },

                new Posts
                {
                    PostId = 3,
                    Title = "China’s economy plunged before major Covid policy shift. A rebound may be months away",
                    ShortDescription = "Hong Kong\r\nCNN\r\n — \r\n \r\nThe end of pandemic restrictions in China will eventually usher in a strong economic rebound as the country learns to live with the Covid virus, according to economists, even as a slew of data showed business activity plummeting in November.",
                    PostContent = "Retail sales declined 5.9% last month from a year ago, according to the National Bureau of Statistics. It was the worst contraction in retail spending since May, when widespread Covid lockdowns pummeled the economy.\r\n\r\nIndustrial production only increased 2.2% in November, less than half of October’s growth. Investment in the property sector, which accounts for as much as 30% of China’s GDP, plunged by 9.8% in the first 11 months of the year. Property sales by value plummeted by more than 26%.\r\n\r\nUnemployment worsened, rising to 5.7% last month, the highest level in six months.\r\n\r\nNovember’s economic slump happened before Beijing rolled back its repressive pandemic restrictions earlier this month. Top leaders signaled at a key political meeting last week that they will shift focus back to growth and seek a turnaround of the economy next year.\r\n\r\n“The November data should be the last batch damaged by zero-Covid,” Wei Yao and Michelle Lam, economists for Societe Generale, wrote in a research note.",
                    UrlSlug = "chinas-economy-plunged-before-major-covid-policy-shift-a-rebound-may-be-months-away",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 1,
                    ViewCount = 300,
                    RateCount = 4,
                    TotalRate = 16,
                },

                new Posts
                {
                    PostId = 4,
                    Title = "The Fed lifts rates by half a point, acknowledging that inflation is easing\r\nNicole Goodkind\r\nBy Nicole Goodkind, CNN",
                    ShortDescription = "Washington, DC\r\nCNN\r\n — \r\nThe Federal Reserve approved a half-point interest rate hike on Wednesday, a smaller increase than in recent months and an acknowledgment that inflation is finally easing.",
                    PostContent = "The increase marks a shift for the central bank after an unprecedented year that includes seven-straight rate hikes as part of an aggressive campaign to try and bring down the highest inflation since the early 1980s.\r\n\r\nWhile lower than the four consecutive three-quarter-point hikes approved at the Fed’s previous meetings, Wednesday’s rate hike is still twice the size of the central bank’s customary quarter-point increase and will likely deepen the economic pain for millions of American businesses and households by pushing up the cost of borrowing even further.\r\n\r\nFed officials will increase the rate that banks charge each other for overnight borrowing to a range of 4.25-4.5%, the highest since 2007.",
                    UrlSlug = "the-fed-lifts-rates-by-half-a-point-acknowledging-that-inflation-is-easing-nicole-goodkind-by-nicole-goodkind-cnn",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 4,
                    ViewCount = 400,
                    RateCount = 30,
                    TotalRate = 40,
                },

                new Posts
                {
                    PostId = 5,
                    Title = "British nurses launch historic strike, as pay and staffing crises threaten the NHS",
                    ShortDescription = "London\r\nCNN\r\n — \r\nNurses across much of the UK launched a historic strike on Thursday",
                    PostContent = "As many as 100,000 members of the Royal College of Nursing (RCN) – the UK’s biggest nursing union – are taking industrial action in England, Wales and Northern Ireland, in the latest and most unprecedented of a wave of strikes that has swept Britain this winter. It is the largest strike in the RCN’s 106-year history.\r\n\r\nBut it comes after several years of hardship for employees of Britain’s National Health Service (NHS), a revered but beleaguered institution that is straining due to staffing shortfalls, sky-high demand and stretched funding.\r\n\r\n“I went into nursing to care for patients, and over the years my capacity to provide the level of care my patients deserve has been compromised,” Andrea Mackay, who has worked as a nurse for seven years at a hospital in southwest England, told CNN on her reasons for striking Thursday.",
                    UrlSlug = "british-nurses-launch-historic-strike-as-pay-and-staffing-crises-threaten-the-nhs",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 5,
                    ViewCount = 210,
                    RateCount = 32,
                    TotalRate = 28,
                },

                new Posts
                {
                    PostId = 6,
                    Title = "Elon Musk sells another 22 million Tesla shares for $3.6 billion",
                    ShortDescription = "New York\r\nCNN\r\n — \r\nElon Musk just sold another 22 million shares of Tesla, raising $3.6 billion.",
                    PostContent = "Musk sold the shares on Monday, Tuesday and Wednesday this week. The sales were disclosed in an SEC filing late Wednesday.\r\n\r\nMusk did not disclose the reason for the sales in the filing. They’re his first sales of Tesla stock since early November, when he sold 19.5 million shares shortly after closing on his purchase of Twitter.\r\n\r\nBefore Musk first started his efforts to buy Twitter, he rarely sold Tesla shares. Typically his sales were tied to what he needed to sell to pay taxes he owed on the exercise of options.\r\n\r\nBut since the first announcing plans to buy Twitter in April he has sold a total of $22.9 billion worth of Tesla stock.\r\n\r\nThose stock sales, and the amount of his attention that has been focused on Twitter, has worried Tesla shareholders and analysts.",
                    UrlSlug = "elon-musk-sells-another-22-million-tesla-shares-for-dollar36-billion",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 6,
                    ViewCount = 300,
                    RateCount = 42,
                    TotalRate = 36,
                },

                new Posts
                {
                    PostId = 7,
                    Title = "The real revelation from the ‘Twitter Files’: Content moderation is messy",
                    ShortDescription = "New York\r\nCNN\r\n — \r\nBefore then-President Donald Trump was banned from Twitter after the Capitol riot last January, there was a debate among some employees about what to do with the company’s most prominent and controversial user.",
                    PostContent = "Some employees questioned whether Trump’s final tweets on the platform actually violated the company’s policies, according to internal documents. Others asked if the tweets could be considered veiled (or “coded”) efforts to dodge Twitter’s rules and requested research to better understand how users might interpret them.\r\n\r\nThe high-stakes debate among several employees, including several top execs, was revealed earlier this week in the latest edition of the “Twitter Files,” a tranche of internal company documents provided to and tweeted out by several journalists unaffiliated with major news organizations. The releases so far have focused on some of the social media company’s most high-profile, and controversial, content moderation decisions.",
                    UrlSlug = "the-real-revelation-from-the-twitter-files-content-moderation-is-messy",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 7,
                    ViewCount = 230,
                    RateCount = 30,
                    TotalRate = 80,
                },

                new Posts
                {
                    PostId = 8,
                    Title = "An Ethiopian professor was murdered by a mob. A lawsuit alleges Facebook fueled the violence",
                    ShortDescription = "\r\nCNN\r\n — \r\nThe son of an Ethiopian chemistry professor who was killed during unrest in the country last year has filed a lawsuit against Meta, Facebook’s parent company, alleging that the social media platform is fueling viral hate and violence, harming people across eastern and southern Africa.",
                    PostContent = "Abrham Meareg Amare claims in the suit that his father, Meareg Amare, a 60-year-old Tigrayan academic, was gunned down outside his home in Bahir Dar, the capital city of Ethiopia’s Amhara region, in November 2021, after a string of hateful messages were posted on Facebook that slandered and doxed the professor, calling for his murder.\r\n\r\nThe case is a constitutional petition filed in Kenya’s High Court, which has jurisdiction over the issue, as Facebook’s content moderation operation hub for much of east and south Africa is located in Nairobi.\r\n\r\nIt accuses Facebook’s algorithm of prioritizing dangerous, hateful and inciteful content in pursuit of engagement and advertising profits in Kenya.\r\n\r\n“They have suffered human rights violations as a result of the Respondent failing to take down Facebook posts that violated the bill of rights even after making reports to the Respondent,” reads the complaint.\r\n\r\nThe legal filing alleges that Facebook has failed to invest adequately in content moderation in countries across Africa, Latin America and the Middle East, particularly from its hub in Nairobi.",
                    UrlSlug = "an-ethiopian-professor-was-murdered-by-a-mob-a-lawsuit-alleges-facebook-fueled-the-violence",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 8,
                    ViewCount = 230,
                    RateCount = 72,
                    TotalRate = 48,
                },

                new Posts
                {
                    PostId = 9,
                    Title = "Democratic lawmakers urge Meta not to restore Trump’s account in January",
                    ShortDescription = "Washington\r\nCNN\r\n — \r\nTwo Democratic lawmakers on Wednesday urged Meta to maintain Donald Trump’s suspension from its platforms when it revisits the matter in January, arguing that the former president’s recent posts on his own social media platform suggest he is likely to violate the social media giant’s policies if given a chance.",
                    PostContent = "The letter from California Rep. Adam Schiff and Rhode Island Sen. Sheldon Whitehouse cites numerous news reports about Trump’s postings on Truth Social, the former president’s Twitter alternative. They characterize his remarks as election misinformation and, in some cases, incitement.\r\n\r\nOn Truth Social, Trump has also reportedly amplified adherents of the QAnon conspiracy theory that Meta banned from its platforms in 2020, the lawmakers wrote.\r\n\r\n“For Meta to credibly maintain a legitimate election integrity policy, it is essential that your company maintain its platform ban on former president Trump,” the letter said. “Based on Meta’s own statement on standards for allowing Trump back on the platform, his account should continue to be restricted.”\r\n\r\nMeta declined to comment on Wednesday’s letter.\r\n\r\nThe company suspended Trump for two years after the Jan. 6 Capitol riots, over concerns he had fomented violence. With the help of outside experts, it plans to assess in early January whether to lift Trump’s restrictions and allow him to post on its platforms once again.",
                    UrlSlug = "democratic-lawmakers-urge-meta-not-to-restore-trumps-account-in-january",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 9,
                    ViewCount = 320,
                    RateCount = 94,
                    TotalRate = 76,
                },

                new Posts
                {
                    PostId = 10,
                    Title = "Why Tom Brady, David Ortiz, Jimmy Fallon and other celebrities are getting sued over crypto",
                    ShortDescription = "New York\r\nCNN\r\n — \r\nWith the implosion of Sam Bankman-Fried’s FTX dominating the headlines, celebrities who hawked cryptocurrency are now finding themselves under fresh legal scrutiny.",
                    PostContent = "Tom Brady, Madonna, Gwyneth Paltrow and baseball Hall-of-Famer David Ortiz are just some of the big names facing lawsuits from investors as the crypto world crumbles in the wake of FTX’s fall from grace.\r\n\r\nThe backlash started earlier this month, when a class-action suit was filed against celebrities, including Jimmy Fallon, Justin Bieber and Serena Williams for promoting Bored Ape Yacht Club NFTs.\r\n\r\nNFTs are a crypto-related phenomenon that went mainstream, essentially transforming digital works of art and other collectibles into one-of-a-kind, verifiable assets that are easy to trade on the blockchain. The Bored Ape Yacht Club is a collection of 10,000 pieces of digital NFT art living on the ethereum (eth) blockchain.\r\n\r\nNone of the celebrities named in the lawsuits immediately responded to requests from CNN for comment.\r\n\r\nTom Brady, Gisele Bundchen and others were sued in November by an FTX investor for their endorsement of the now-disgraced crypto platform, and then Brady and Ortiz were named again in early December in a similar lawsuit for their backing of FTX.",
                    UrlSlug = "why-tom-brady-david-ortiz-jimmy-fallon-and-other-celebrities-are-getting-sued-over-crypto",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 10,
                    ViewCount = 300,
                    RateCount = 24,
                    TotalRate = 36,
                }
            );

            // Add data into Tags
            builder.Entity<Tags>().HasData(
               new Tags
               {
                   TagId = 1,
                   Name = "Fashion",
                   UrlSlug = "fashion",
                   Description = "Posts related to fashion and clothing",
                   Count = 10,
               },

               new Tags
               {
                   TagId = 2,
                   Name = "Recipes",
                   UrlSlug = "recipes",
                   Description = "Posts related to food and recipes",
                   Count = 9,

               },

               new Tags
               {
                   TagId = 3,
                   Name = "Sports",
                   UrlSlug = "sports",
                   Description = "Posts related to sports, games and physical activities",
                   Count = 8,
               },
               new Tags
               {
                   TagId = 4,
                   Name = "Productivity",
                   UrlSlug = "productivity",
                   Description = "This tag might be used on a blog post about time management tips, goal setting strategies, or ways to increase productivity at work.",
                   Count = 7,
               },

               new Tags
               {
                   TagId = 5,
                   Name = "Technology",
                   UrlSlug = "technology",
                   Description = "This tag might be used on a blog post about new tech gadgets, software updates, or technology news.\r\n\r\n",
                   Count = 6,

               },

               new Tags
               {
                   TagId = 6,
                   Name = "Wellness",
                   UrlSlug = "wellness",
                   Description = "This tag might be used on a blog post about self-care practices, mental health tips, or natural remedies.",
                   Count = 5,
               },
               new Tags
               {
                   TagId = 7,
                   Name = "Parenting",
                   UrlSlug = "parenting",
                   Description = "This tag might be used on a blog post about tips for raising children, stories about parenthood, or resources for new parents.",
                   Count = 4,
               },

               new Tags
               {
                   TagId = 8,
                   Name = "Education",
                   UrlSlug = "education",
                   Description = "This tag might be used on a blog post about teaching strategies, educational resources, or trends in education.",
                   Count = 3,

               },

               new Tags
               {
                   TagId = 9,
                   Name = "Entrepreneurship",
                   UrlSlug = "entrepreneurship",
                   Description = "This tag might be used on a blog post about starting a business, growing a brand, or tips for entrepreneurs.",
                   Count = 2,
               },

               new Tags
               {
                   TagId = 10,
                   Name = "Art",
                   UrlSlug = "art",
                   Description = "This tag might be used on a blog post about a new art exhibit, a review of a book or movie, or an artist interview.",
                   Count = 1,
               }
            );

            // Add data into PostTagMap
            builder.Entity<PostTagMap>().HasData(
                new PostTagMap
                {
                    PostId = 1,
                    TagId = 2,
                },

                new PostTagMap
                {
                    PostId = 2,
                    TagId = 3,
                },

                new PostTagMap
                {
                    PostId = 3,
                    TagId = 1,
                },

                 new PostTagMap
                 {
                     PostId = 4,
                     TagId = 4,
                 },

                new PostTagMap
                {
                    PostId = 5,
                    TagId = 5,
                },

                new PostTagMap
                {
                    PostId = 6,
                    TagId = 6,
                },
                 new PostTagMap
                 {
                     PostId = 7,
                     TagId = 7,
                 },

                new PostTagMap
                {
                    PostId = 8,
                    TagId = 8,
                },

                new PostTagMap
                {
                    PostId = 9,
                    TagId = 9,
                },

                new PostTagMap
                {
                    PostId = 10,
                    TagId = 10,
                }
            );

            // Add data into Comments
            builder.Entity<Comments>().HasData(
                new Comments
                {
                    CommentId = 1,
                    Name = "Pham Phu Son",
                    Email = "sonpp@gmail.com",
                    PostId = 1,
                    CommentHeader = "Very nice",
                    CommentText = "This post is very amazing",
                    CommentTime = DateTime.Now
                },

                new Comments
                {
                    CommentId = 2,
                    Name = "John Cena",
                    Email = "john@gmail.com",
                    PostId = 2,
                    CommentHeader = "Very nice",
                    CommentText = "This post is very amazing",
                    CommentTime = DateTime.Now
                },

                new Comments
                {
                    CommentId = 3,
                    Name = "Masson Doe",
                    Email = "doeM@gmail.com",
                    PostId = 3,
                    CommentHeader = "Very nice",
                    CommentText = "This post is very amazing",
                    CommentTime = DateTime.Now
                }
            );


        }
    }
}
