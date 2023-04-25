using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMap",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMap", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMap_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMap_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "Posts related to technology", "Tech", "tech" },
                    { 2, "Posts related to health and wellness", "Food", "tech" },
                    { 3, "Posts related to movies, music, and other forms of entertainment", "Travel", "tech" },
                    { 4, "A blog that focuses on self-improvement, motivation, and success strategies.", "Personal Development", "personal-development" },
                    { 5, "A blog that covers topics such as fashion, travel, food, and relationships.", "Lifestyle", "lifestyle" },
                    { 6, "A blog that provides tips, advice, and stories on raising children, from infancy to teenage years.", "Parenting", "parenting" },
                    { 7, "A blog that covers topics such as teaching strategies, educational resources, and trends in education.", "Education", "education" },
                    { 8, "A blog that provides insights, tips, and news on entrepreneurship, finance, and management.", "Business and Finance", "business-and-finance" },
                    { 9, "A blog that covers topics such as music, movies, art, literature, and other forms of cultural expression.", "Arts and Culture", "arts-and-culture" },
                    { 10, "A blog that discusses topics such as fitness, nutrition, mental health, and natural remedies.", "Health and Wellness", "health-and-wellness" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 10, "Posts related to fashion and clothing", "Fashion", "fashion" },
                    { 2, 9, "Posts related to food and recipes", "Recipes", "recipes" },
                    { 3, 8, "Posts related to sports, games and physical activities", "Sports", "sports" },
                    { 4, 7, "This tag might be used on a blog post about time management tips, goal setting strategies, or ways to increase productivity at work.", "Productivity", "productivity" },
                    { 5, 6, "This tag might be used on a blog post about new tech gadgets, software updates, or technology news.\r\n\r\n", "Technology", "technology" },
                    { 6, 5, "This tag might be used on a blog post about self-care practices, mental health tips, or natural remedies.", "Wellness", "wellness" },
                    { 7, 4, "This tag might be used on a blog post about tips for raising children, stories about parenthood, or resources for new parents.", "Parenting", "parenting" },
                    { 8, 3, "This tag might be used on a blog post about teaching strategies, educational resources, or trends in education.", "Education", "education" },
                    { 9, 2, "This tag might be used on a blog post about starting a business, growing a brand, or tips for entrepreneurs.", "Entrepreneurship", "entrepreneurship" },
                    { 10, 1, "This tag might be used on a blog post about a new art exhibit, a review of a book or movie, or an artist interview.", "Art", "art" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1740), "Washington\r\nCNN\r\n — \r\nThe United States added a major Chinese chipmaker and dozens of other Chinese companies to a trade blacklist Thursday as it works to restrict Beijing’s high-tech and artificial intelligence industries.\r\n\r\nAdding chipmaker YMTC to the list of restricted companies escalates Washington’s attempts to crack down on companies that could be used to bolster China’s military.\r\n\r\nThe restrictions would ban US companies from shipping goods to some of the blacklisted companies without first obtaining a special license. Other companies will be further restricted from buying any product made using American technology.\r\n\r\nThe US has been working steadily to limit what business US companies can do with Chinese firms that the US suspects of aiding China’s military or its human rights abuses.\r\n\r\nIn October, the US imposed sweeping new curbs designed to curtail China’s access to technology critical to the manufacturing and operations of its military power. The US alleges the companies added to the lists pose a national security threat, including by helping power artificial intelligence technology and hypersonic missiles\r\n\r\nThe latest moves come weeks after President Joe Biden met for the first time face-to-face with Chinese President Xi Jinping. The talks were intended as a starting-off point for greater communication between the two world superpowers.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1726), true, 10, "As part of Thursday’s announcement, the US also said it was removing some Chinese companies from a so-called “watch list” after the firms were deemed to not pose a risk to US national security.", "US toughens restrictions on Chinese tech firms linked to military", 20, "us-toughens-restrictions-on-chinese-tech-firms-linked-to-military", 100 },
                    { 2, 2, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1744), "The latest legislative action comes as TikTok and the US government have been negotiating a deal that may allow the app to keep serving US users. There have been years of closed-door talks between TikTok and the Committee on Foreign Investment in the United States, as well as recent reports of delays in the negotiations.\r\n\r\nSome lawmakers have expressed frustration with an apparent lack of progress in those talks. Following Wednesday’s vote, Virginia Democratic Sen. Mark Warner, a vocal critic of TikTok, said of the process: “My patience is running out.”\r\n\r\nOn Tuesday, US lawmakers led by Florida Republican Sen. Marco Rubio introduced a bill to ban TikTok in the United States more generally, along with other apps based in, or under the “substantial influence” of, countries that are considered foreign adversaries, including China, Russia, Iran, North Korea, Cuba and Venezuela. In introducing the bill, Rubio also indicated some frustration, saying that the federal government “has yet to take a single meaningful action” on the matter.\r\n\r\nBut several senators, including Warner and Hawley, have stopped short of endorsing Rubio’s proposal. On Thursday, Hawley said he would be “fine” if the US government and TikTok reached a deal to safeguard US users’ data. “But if they don’t do that … then I think we’re going to have to look at more stringent measures,” Hawley said.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1743), true, 7, "\r\nCNN\r\n — \r\nThe Senate passed legislation Wednesday evening to ban TikTok from US government devices, in a move designed to limit perceived information-security risks stemming from the social media app.", "Senate passes legislation to ban TikTok from US government devices", 28, "senate-passes-legislation-to-ban-tiktok-from-us-government-devices", 200 },
                    { 3, 1, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1746), "Retail sales declined 5.9% last month from a year ago, according to the National Bureau of Statistics. It was the worst contraction in retail spending since May, when widespread Covid lockdowns pummeled the economy.\r\n\r\nIndustrial production only increased 2.2% in November, less than half of October’s growth. Investment in the property sector, which accounts for as much as 30% of China’s GDP, plunged by 9.8% in the first 11 months of the year. Property sales by value plummeted by more than 26%.\r\n\r\nUnemployment worsened, rising to 5.7% last month, the highest level in six months.\r\n\r\nNovember’s economic slump happened before Beijing rolled back its repressive pandemic restrictions earlier this month. Top leaders signaled at a key political meeting last week that they will shift focus back to growth and seek a turnaround of the economy next year.\r\n\r\n“The November data should be the last batch damaged by zero-Covid,” Wei Yao and Michelle Lam, economists for Societe Generale, wrote in a research note.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1745), true, 4, "Hong Kong\r\nCNN\r\n — \r\n \r\nThe end of pandemic restrictions in China will eventually usher in a strong economic rebound as the country learns to live with the Covid virus, according to economists, even as a slew of data showed business activity plummeting in November.", "China’s economy plunged before major Covid policy shift. A rebound may be months away", 16, "chinas-economy-plunged-before-major-covid-policy-shift-a-rebound-may-be-months-away", 300 },
                    { 4, 4, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1748), "The increase marks a shift for the central bank after an unprecedented year that includes seven-straight rate hikes as part of an aggressive campaign to try and bring down the highest inflation since the early 1980s.\r\n\r\nWhile lower than the four consecutive three-quarter-point hikes approved at the Fed’s previous meetings, Wednesday’s rate hike is still twice the size of the central bank’s customary quarter-point increase and will likely deepen the economic pain for millions of American businesses and households by pushing up the cost of borrowing even further.\r\n\r\nFed officials will increase the rate that banks charge each other for overnight borrowing to a range of 4.25-4.5%, the highest since 2007.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1747), true, 30, "Washington, DC\r\nCNN\r\n — \r\nThe Federal Reserve approved a half-point interest rate hike on Wednesday, a smaller increase than in recent months and an acknowledgment that inflation is finally easing.", "The Fed lifts rates by half a point, acknowledging that inflation is easing\r\nNicole Goodkind\r\nBy Nicole Goodkind, CNN", 40, "the-fed-lifts-rates-by-half-a-point-acknowledging-that-inflation-is-easing-nicole-goodkind-by-nicole-goodkind-cnn", 400 },
                    { 5, 5, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1750), "As many as 100,000 members of the Royal College of Nursing (RCN) – the UK’s biggest nursing union – are taking industrial action in England, Wales and Northern Ireland, in the latest and most unprecedented of a wave of strikes that has swept Britain this winter. It is the largest strike in the RCN’s 106-year history.\r\n\r\nBut it comes after several years of hardship for employees of Britain’s National Health Service (NHS), a revered but beleaguered institution that is straining due to staffing shortfalls, sky-high demand and stretched funding.\r\n\r\n“I went into nursing to care for patients, and over the years my capacity to provide the level of care my patients deserve has been compromised,” Andrea Mackay, who has worked as a nurse for seven years at a hospital in southwest England, told CNN on her reasons for striking Thursday.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1750), true, 32, "London\r\nCNN\r\n — \r\nNurses across much of the UK launched a historic strike on Thursday", "British nurses launch historic strike, as pay and staffing crises threaten the NHS", 28, "british-nurses-launch-historic-strike-as-pay-and-staffing-crises-threaten-the-nhs", 210 },
                    { 6, 6, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1752), "Musk sold the shares on Monday, Tuesday and Wednesday this week. The sales were disclosed in an SEC filing late Wednesday.\r\n\r\nMusk did not disclose the reason for the sales in the filing. They’re his first sales of Tesla stock since early November, when he sold 19.5 million shares shortly after closing on his purchase of Twitter.\r\n\r\nBefore Musk first started his efforts to buy Twitter, he rarely sold Tesla shares. Typically his sales were tied to what he needed to sell to pay taxes he owed on the exercise of options.\r\n\r\nBut since the first announcing plans to buy Twitter in April he has sold a total of $22.9 billion worth of Tesla stock.\r\n\r\nThose stock sales, and the amount of his attention that has been focused on Twitter, has worried Tesla shareholders and analysts.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1751), true, 42, "New York\r\nCNN\r\n — \r\nElon Musk just sold another 22 million shares of Tesla, raising $3.6 billion.", "Elon Musk sells another 22 million Tesla shares for $3.6 billion", 36, "elon-musk-sells-another-22-million-tesla-shares-for-dollar36-billion", 300 },
                    { 7, 7, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1754), "Some employees questioned whether Trump’s final tweets on the platform actually violated the company’s policies, according to internal documents. Others asked if the tweets could be considered veiled (or “coded”) efforts to dodge Twitter’s rules and requested research to better understand how users might interpret them.\r\n\r\nThe high-stakes debate among several employees, including several top execs, was revealed earlier this week in the latest edition of the “Twitter Files,” a tranche of internal company documents provided to and tweeted out by several journalists unaffiliated with major news organizations. The releases so far have focused on some of the social media company’s most high-profile, and controversial, content moderation decisions.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1753), true, 30, "New York\r\nCNN\r\n — \r\nBefore then-President Donald Trump was banned from Twitter after the Capitol riot last January, there was a debate among some employees about what to do with the company’s most prominent and controversial user.", "The real revelation from the ‘Twitter Files’: Content moderation is messy", 80, "the-real-revelation-from-the-twitter-files-content-moderation-is-messy", 230 },
                    { 8, 8, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1755), "Abrham Meareg Amare claims in the suit that his father, Meareg Amare, a 60-year-old Tigrayan academic, was gunned down outside his home in Bahir Dar, the capital city of Ethiopia’s Amhara region, in November 2021, after a string of hateful messages were posted on Facebook that slandered and doxed the professor, calling for his murder.\r\n\r\nThe case is a constitutional petition filed in Kenya’s High Court, which has jurisdiction over the issue, as Facebook’s content moderation operation hub for much of east and south Africa is located in Nairobi.\r\n\r\nIt accuses Facebook’s algorithm of prioritizing dangerous, hateful and inciteful content in pursuit of engagement and advertising profits in Kenya.\r\n\r\n“They have suffered human rights violations as a result of the Respondent failing to take down Facebook posts that violated the bill of rights even after making reports to the Respondent,” reads the complaint.\r\n\r\nThe legal filing alleges that Facebook has failed to invest adequately in content moderation in countries across Africa, Latin America and the Middle East, particularly from its hub in Nairobi.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1755), true, 72, "\r\nCNN\r\n — \r\nThe son of an Ethiopian chemistry professor who was killed during unrest in the country last year has filed a lawsuit against Meta, Facebook’s parent company, alleging that the social media platform is fueling viral hate and violence, harming people across eastern and southern Africa.", "An Ethiopian professor was murdered by a mob. A lawsuit alleges Facebook fueled the violence", 48, "an-ethiopian-professor-was-murdered-by-a-mob-a-lawsuit-alleges-facebook-fueled-the-violence", 230 },
                    { 9, 9, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1759), "The letter from California Rep. Adam Schiff and Rhode Island Sen. Sheldon Whitehouse cites numerous news reports about Trump’s postings on Truth Social, the former president’s Twitter alternative. They characterize his remarks as election misinformation and, in some cases, incitement.\r\n\r\nOn Truth Social, Trump has also reportedly amplified adherents of the QAnon conspiracy theory that Meta banned from its platforms in 2020, the lawmakers wrote.\r\n\r\n“For Meta to credibly maintain a legitimate election integrity policy, it is essential that your company maintain its platform ban on former president Trump,” the letter said. “Based on Meta’s own statement on standards for allowing Trump back on the platform, his account should continue to be restricted.”\r\n\r\nMeta declined to comment on Wednesday’s letter.\r\n\r\nThe company suspended Trump for two years after the Jan. 6 Capitol riots, over concerns he had fomented violence. With the help of outside experts, it plans to assess in early January whether to lift Trump’s restrictions and allow him to post on its platforms once again.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1759), true, 94, "Washington\r\nCNN\r\n — \r\nTwo Democratic lawmakers on Wednesday urged Meta to maintain Donald Trump’s suspension from its platforms when it revisits the matter in January, arguing that the former president’s recent posts on his own social media platform suggest he is likely to violate the social media giant’s policies if given a chance.", "Democratic lawmakers urge Meta not to restore Trump’s account in January", 76, "democratic-lawmakers-urge-meta-not-to-restore-trumps-account-in-january", 320 },
                    { 10, 10, new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1762), "Tom Brady, Madonna, Gwyneth Paltrow and baseball Hall-of-Famer David Ortiz are just some of the big names facing lawsuits from investors as the crypto world crumbles in the wake of FTX’s fall from grace.\r\n\r\nThe backlash started earlier this month, when a class-action suit was filed against celebrities, including Jimmy Fallon, Justin Bieber and Serena Williams for promoting Bored Ape Yacht Club NFTs.\r\n\r\nNFTs are a crypto-related phenomenon that went mainstream, essentially transforming digital works of art and other collectibles into one-of-a-kind, verifiable assets that are easy to trade on the blockchain. The Bored Ape Yacht Club is a collection of 10,000 pieces of digital NFT art living on the ethereum (eth) blockchain.\r\n\r\nNone of the celebrities named in the lawsuits immediately responded to requests from CNN for comment.\r\n\r\nTom Brady, Gisele Bundchen and others were sued in November by an FTX investor for their endorsement of the now-disgraced crypto platform, and then Brady and Ortiz were named again in early December in a similar lawsuit for their backing of FTX.", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1761), true, 24, "New York\r\nCNN\r\n — \r\nWith the implosion of Sam Bankman-Fried’s FTX dominating the headlines, celebrities who hawked cryptocurrency are now finding themselves under fresh legal scrutiny.", "Why Tom Brady, David Ortiz, Jimmy Fallon and other celebrities are getting sued over crypto", 36, "why-tom-brady-david-ortiz-jimmy-fallon-and-other-celebrities-are-getting-sued-over-crypto", 300 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Very nice", "This post is very amazing", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1813), "sonpp@gmail.com", "Pham Phu Son", 1 },
                    { 2, "Very nice", "This post is very amazing", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1814), "john@gmail.com", "John Cena", 2 },
                    { 3, "Very nice", "This post is very amazing", new DateTime(2023, 4, 24, 14, 36, 47, 973, DateTimeKind.Local).AddTicks(1815), "doeM@gmail.com", "Masson Doe", 3 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMap",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMap_TagId",
                table: "PostTagMap",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMap");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
