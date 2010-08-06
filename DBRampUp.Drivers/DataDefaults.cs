using System;
using System.Collections.Generic;
using System.Text;

namespace DBRampUp
{
    public static class DataDefaults
    {
        public static string GetString(Int32 maxLength)
        {
            return GetString(1,maxLength, false, -1, true);
        }

        public static string GetString(Int32 maxLength, bool numericOnly)
        {
            return GetString(1, maxLength, numericOnly, -1, true);
        }        
        public static string GetString(Int32 maxLength, bool numericOnly, bool useSpaces)
        {
            return GetString(1, maxLength, numericOnly, -1, useSpaces);
        }
        public static string GetString(Int32 maxLength, bool numericOnly, Int32 maxValue)
        {
            return GetString(1, maxLength, numericOnly, maxValue, true);
        }
        public static string GetString(Int32 minLength, Int32 maxLength)
        {
            return GetString(minLength, maxLength, false, -1, true);
        }

        public static string GetString(Int32 minLength, Int32 maxLength, bool numericOnly)
        {
            return GetString(minLength, maxLength, numericOnly, -1, true);
        }
        public static string GetString(Int32 minLength, Int32 maxLength, bool numericOnly, bool useSpaces)
        {
            return GetString(minLength, maxLength, numericOnly, -1, useSpaces);
        }
        public static string GetString(Int32 minLength, Int32 maxLength, bool numericOnly, Int32 maxValue)
        {
            return GetString(minLength, maxLength, numericOnly, maxValue, true);
        }
        public static Random rnd = new Random();

        #region strings


        public static bool UseEnglishWordList = true;

        public static string[] BUNCH_OF_WORDS
        {
            get
            {
                if (UseEnglishWordList)
                    return EnglishText;
                else
                    return (LOREM_IPSUM1 + LOREM_IPSUM2).Split(" ".ToCharArray());
            }
        }
        private static string[] _bunch_of_tags;
        public static string[] BUNCH_OF_TAGS 
        {
            get
            {
                if (_bunch_of_tags == null) _bunch_of_tags = GetBunchOfText(255, false).Split(" ".ToCharArray());
            	return _bunch_of_tags;
            }
        }
         //*/{ "Cool Stuff", "Hilarious", "OMG", "achievement", "equipment", "building & creating", "WTF", "ErrorPage", "Crash", "rtfm", "Rules Requirements & Categorization", "Organize Files", "Folders", "error", "Book", "Contact List", "annoyingly long tag that somehow got popular", "lookout!", "society", "off-topic", "Interpretation", "busy", "software", "soldier", "patient", "assembly" };
        public static string[] BUNCH_OF_PUNCTUATIONS = { "! ", ". ", "; ", ", ", " & ", " (", ") " };


        public const string LOREM_IPSUM1 = "Lorem ipsum dolor sit amet consectetuer adipiscing elit Donec dictum ante nec quam "
                                  + "Fusce odio Donec ac tellus a odio porta fringilla Pellentesque sodales tortor in iaculis "
                                  + "auctor justo lectus cursus nibh vel pharetra nulla magna ut nibh.Pellentesque mattis dictum "
                                  + "metus Vestibulum consectetuer tempus mauris sociis natoque penatibus et magnis dis parturient "
                                  + "montes nascetur ridiculus mus";
        public const string LOREM_IPSUM2 = "Donec sed tellus Fusce tincidunt mauris id dui Sed viverra metus ac dui In porttitor aliquam "
                                          + "diam Aliquam iaculis Cras quis turpis et nulla hendrerit tincidunt Etiam sed est quis felis "
                                          + "scelerisque tincidunt Morbi quam dolor dignissim vitae semper ut luctus eget ligula "
                                          + "Curabitur in lorem Praesent urna Ut magna tellus vehicula a consequat acondimentum at "
                                          + "lacus";

		public static string[] FirstNames = new string[]{
        "Michael","Christopher","Joshua","Matthew","Daniel","David","Andrew","Justin","Ryan","Robert","James","Nicholas","Joseph","John","Jonathan","Kevin","Kyle","Brandon","William","Eric","Jose","Steven","Jacob","Brian","Tyler","Zachary","Aaron","Alexander","Adam","Thomas","Richard","Timothy","Benjamin","Jason","Jeffrey","Sean","Jordan","Jeremy","Travis","Cody","Nathan","Mark","Jesse","Charles","Juan","Samuel","Patrick","Dustin","Scott","Stephen","Paul","Bryan","Luis","Derek","Austin","Kenneth","Carlos","Gregory","Alex","Cameron","Jared","Jesus","Bradley","Christian","Corey","Victor","Cory","Miguel","Tylor","Edward","Francisco","Trevor","Adrian","Jorge","Ian","Antonio","Shawn","Ricardo","Vincent","Edgar","Erik","Peter","Shane","Evan","Chad","Alejandro","Brett","Gabriel","Eduardo","Raymond","Phillip","Mario","Marcus","Manuel","George","Martin","Spencer","Garrett","Casey",
        "Jessica","Ashley","Amanda","Brittany","Sarrah","Jennifer","Stephanie","Samantha","Elizabeth","Megan","Nicole","Lauren","Melissa","Amber","Michelle","Heather","Christina","Rachel","Tiffany","Kayla","Danielle","Vanessa","Rebecca","Laura","Courtney","Katherine","Chelsea","Kimberly","Sara","Kelsey","Andrea","Alyssa","Crystal","Maria","Amy","Alexandra","Erica","Jasmine","Natalie","Hanna","Angela","Kelly","Brittney","Mary","Cassandra","Erin","Victoria","Jacqueline","Jamie","Lindsey","Alicia","Lisa","Katie","Allison","Kristen","Cynthia","Anna","Caitlin","Monica","Christine","Diana","Erika","Veronica","Kathryn","Whitney","Brianna","Nancy","Shannon","Kristina","Lindsay","Kristin","Marissa","Patricia","Brooke","Brenda","Angelica","Morgan","Adriana","April","Ana","Taylor","Tara","Jordan","Jenna","Catherine","Alexis","Karen","Melanie","Natasha","Sandra","Julie","Bianca","Krystal","Mayra","Holly","Alexandria","Monique","Leslie","Katelyn"     
        };

		public static string[] LastNames = new string[] {
               "Smith",
        "Johnson",
        "Williams",
        "Jones",
        "Brown",
        "Davis",
        "Miller",
        "Wilson",
        "Moore",
        "Taylor",
        "Anderson",
        "Thomas",
        "Jackson",
        "White",
        "Harris",
        "Martin",
        "Thompson",
        "Garcia",
        "Martinez",
        "Robinson",
        "Clark",
        "Rodriguez",
        "Lewis",
        "Lee",
        "Walker",
        "Hall",
        "Allen",
        "Young",
        "Hernandez",
        "King",
        "Wright",
        "Lopez",
        "Hill",
        "Scott",
        "Green",
        "Adams",
        "Baker",
        "Gonzalez",
        "Nelson",
        "Carter",
        "Mitchell",
        "Perez",
        "Roberts",
        "Turner",
        "Phillips",
        "Campbell",
        "Parker",
        "Evans",
        "Edwards",
        "Collins",
        "Stewart",
        "Sanchez",
        "Morris",
        "Rogers",
        "Reed",
        "Cook",
        "Morgan",
        "Bell",
        "Murphy",
        "Bailey",
        "Rivera",
        "Cooper",
        "Richardson",
        "Cox",
        "Howard",
        "Ward",
        "Torres",
        "Peterson",
        "Gray",
        "Ramirez",
        "James",
        "Watson",
        "Brooks",
        "Kelly",
        "Sanders",
        "Price",
        "Bennett",
        "Wood",
        "Barnes",
        "Ross",
        "Henderson",
        "Coleman",
        "Jenkins",
        "Perry",
        "Powell",
        "Long",
        "Patterson",
        "Hughes",
        "Flores",
        "Washington",
        "Butler",
        "Simmons",
        "Foster",
        "Gonzales",
        "Bryant",
        "Alexander",
        "Russell",
        "Griffin",
        "Diaz",
        "Hayes"

        };

        public static string[] EnglishText = new string[] {"&", ":-)", "a","a","a","a","ability","able","about","about","above","above","absence","absolutely","academic","accept","access","accident","accompany",
"according to","account","account","achieve","achievement","acid","acquire","across","act","act","action","active","activity","actual","actually","add","addition","additional","address","address","administration","admit","adopt",
"adult","advance","advantage","advice","advise","affair","affect","afford","afraid","after","after","afternoon","afterwards","again","against","age","agency","agent","ago","agree","agreement","ahead","aid","aim","aim","air","aircraft",
"all","all","allow","almost","alone","alone","along","along","already","alright","also","alternative","alternative","although","always","among","amongst","amount","an","analysis","ancient","and","animal","announce",
"annual","another","answer","answer","any","anybody","anyone","anything","anyway","apart","apparent","apparently","appeal","appeal","appear","appearance","application","apply","appoint","appointment","approach","approach","appropriate","approve","area","argue","argument","arise","arm","army","around","around","arrange","arrangement","arrive","art","article","artist","as","as","as","ask","aspect","assembly","assess","assessment","asset","associate","association","assume","assumption","at","atmosphere","attach","attack","attack","attempt","attempt","attend","attention","attitude","attract","attractive","audience","author","authority","available","average","avoid","award","award","aware","away","aye","baby","back","back","background","bad","bag","balance","ball","band","bank","bar","base","base","basic","basis","battle","be","bear","beat","beautiful","because","become","bed","bedroom","before","before","before","begin","beginning","behaviour","behind","belief","believe","belong","below","below","beneath","benefit","beside","best","better","between","beyond","big","bill","bind","bird","birth","bit","black","block","blood","bloody","blow","blue","board","boat","body","bone","book","border","both","both","bottle","bottom","box","boy","brain","branch","break","breath","bridge","brief","bright","bring","broad",
"brother","budget","build","building","burn","bus","business","busy","but","buy","by","cabinet","call","call","campaign","can","candidate","capable","capacity","capital","car","card","care","care","career","careful","carefully","carry","case","cash","cat","catch","category","cause","cause","cell","central","centre","century","certain","certainly","chain","chair","chairman","challenge","chance","change","change","channel","chapter","character","characteristic","charge","charge","cheap","check","chemical","chief","child","choice","choose","church","circle","circumstance","citizen","city","civil","claim","claim","class","clean","clear","clear","clearly","client","climb","close","close","close","closely","clothes","club","coal","code","coffee","cold","colleague","collect","collection","college","colour","combination","combine","come","comment","comment","commercial","commission","commit","commitment","committee","common","communication","community","company","compare","comparison","competition","complete","complete","completely","complex","component","computer","concentrate","concentration","concept","concern","concern","concerned","conclude","conclusion","condition","conduct","conference","confidence","confirm","conflict","congress","connect","connection","consequence","conservative","consider","considerable","consideration","consist","constant","construction","consumer","contact","contact","contain","content","context","continue","contract","contrast","contribute","contribution","control","control","convention","conversation","copy","corner","corporate","correct","cos","cost","cost","could","council","count","country","county","couple","course","court","cover","cover","create","creation","credit","crime","criminal","crisis","criterion","critical","criticism","cross","crowd","cry","cultural","culture","cup","current","currently","curriculum","customer","cut","cut","damage","damage","danger","dangerous","dark","data","date","date","daughter","day","dead","deal","deal","death","debate","debt","decade","decide","decision","declare","deep","deep","defence","defendant","define","definition","degree","deliver","demand","demand","democratic","demonstrate","deny","department","depend","deputy","derive","describe","description","design","design","desire","desk","despite","destroy","detail","detailed","determine","develop","development","device","die","difference","different","difficult","difficulty","dinner","direct","direct","direction","directly","director","disappear","discipline","discover","discuss","discussion","disease","display","display","distance","distinction","distribution","district","divide","division","do","doctor","document","dog","domestic","door","double","doubt","down","down","draw","drawing","dream","dress","dress","drink","drink","drive","drive","driver","drop","drug","dry","due","during","duty","each","ear","early","early","earn","earth","easily","east","easy","eat","economic","economy","edge","editor","education","educational","effect","effective","effectively","effort","egg","either","either","elderly","election","element","else","elsewhere","emerge","emphasis","employ","employee","employer","employment","empty","enable","encourage","end","end","enemy","energy","engine","engineering","enjoy","enough","enough",
"ensure","enter","enterprise","entire","entirely","entitle","entry","environment","environmental","equal","equally","equipment","error","escape","especially","essential","establish","establishment","estate","estimate","even","evening","event","eventually","ever","every","everybody","everyone","everything","evidence","exactly","examination","examine","example","excellent","except","exchange","executive","exercise","exercise","exhibition","exist","existence","existing","expect","expectation","expenditure","expense","expensive","experience","experience","experiment","expert","explain","explanation","explore","express","expression","extend","extent","external","extra","extremely","eye","face","face","facility","fact","factor","factory","fail","failure","fair","fairly","faith","fall","fall","familiar","family","famous","far","far","farm","farmer","fashion","fast","fast","father","favour","fear","fear","feature","fee","feel","feeling","female","few","few","field","fight","figure","file","fill","film","final","finally","finance","financial","find","finding","fine","finger","finish","fire","firm","first","fish","fit","fix","flat","flight","floor","flow","flower","fly","focus","follow","following","food","foot","football","for","for","force","force","foreign","forest","forget","form","form","formal","former","forward","foundation","free","freedom","frequently","fresh","friend","from","front","front","fruit","fuel","full","fully","function","fund","funny","further","future","future","gain","game","garden","gas","gate","gather","general","general","generally","generate","generation","gentleman","get","girl","give","glass","go","goal","god","gold","good","good","government","grant","grant","great","green","grey","ground","group","grow","growing","growth","guest","guide","gun","hair","half","half","hall","hand","hand","handle","hang","happen","happy","hard","hard","hardly","hate","have","he","head","head","health","hear","heart","heat","heavy","hell","help","help","hence","her","her","here","herself","hide","high","high","highly","hill","him","himself","his","his","historical","history","hit","hold","hole","holiday","home","home","hope","hope","horse","hospital","hot","hotel","hour","house","household","housing","how","however","huge","human","human","hurt","husband","i","idea","identify","if","ignore","illustrate","image","imagine","immediate","immediately","impact","implication","imply","importance","important","impose","impossible","impression","improve","improvement","in","in","incident","include","including","income","increase","increase","increased","increasingly","indeed","independent","index",
"indicate","individual","individual","industrial","industry","influence","influence","inform","information","initial","initiative","injury","inside","inside","insist","instance","instead","institute","institution","instruction","instrument","insurance","intend","intention","interest","interested","interesting","internal","international","interpretation","interview","into","introduce","introduction","investigate","investigation","investment","invite","involve","iron","island","issue","issue","it","is","item","its","itself","job","join","joint","journey","judge","judge","jump","just","justice","keep","key","key","kid","kill","kind","king","kitchen","knee","know","knowledge","labour","labour","lack","lady","land","language","large","largely","last","last","late","late","later","latter","laugh","launch","law","lawyer","lay","lead","lead","leader","leadership","leading","leaf","league","lean","learn","least","leave","left","leg","legal","legislation","length","less","less","let","letter","level","liability","liberal","library","lie","life","lift","light","light","like","like","likely","limit","limit","limited","line","link","link","lip","list","listen","literature","little","little","little","live","living","loan","local","location","long","long","look","look","lord","lose","loss","lot","love","love","lovely","low","lunch","machine","magazine","main","mainly","maintain","major","majority","make","male","male","man","manage","management","manager","manner","many","map","mark","mark","market","market","marriage","married","marry","mass","master","match","match","material","matter","matter","may","may","maybe","me","meal","mean","meaning","means","meanwhile","measure","measure","mechanism","media","medical","meet","meeting","member","membership","memory","mental","mention","merely","message","metal","method","middle","might","mile","military","milk","mind","mind","mine","minister","ministry","minute","miss","mistake","model","modern","module","moment","money","month","more","more","morning","most","most","mother","motion","motor","mountain","mouth","move","move","movement","much","much","murder","museum","music","must","my","myself","name","name","narrow","nation","national","natural","nature","near","nearly","necessarily","necessary","neck","need","need","negotiation","neighbour","neither","network","never","nevertheless","new","news","newspaper","next","next","nice","night","no","no","no","no-one","nobody","nod","noise","none","nor","normal","normally","north","northern","nose","not","note","note","nothing","notice","notice","notion","now","nuclear","number","nurse","object","objective","observation","observe","obtain","obvious","obviously","occasion","occur","odd","of","off","off","offence","offer","offer","office","officer","official","official","often","oil","okay","old","on","on","once","once","one","only","only","onto","open","open","operate","operation","opinion","opportunity","opposition","option","or","order","order","ordinary","organisation","organise","organization","origin","original",
"other","other","other","otherwise","ought","our","ourselves","out","outcome","output","outside","outside","over","over","overall","own","own","owner","package","page","pain","paint","painting","pair","panel","paper","parent","park","parliament","part","particular","particularly","partly","partner","party","pass","passage","past","past","past","path","patient","pattern","pay","pay","payment","peace","pension","people","per","percent","perfect","perform","performance","perhaps","period","permanent","person","personal","persuade","phase","phone","photograph","physical","pick","picture","piece","place","place","plan","plan","planning","plant","plastic","plate","play","play","player","please","pleasure","plenty","plus","pocket","point","point","police","policy","political","politics","pool","poor","popular","population","position","positive","possibility","possible","possibly","post","potential","potential","pound","power","powerful","practical","practice","prefer","prepare","presence","present","present","present","president","press","press","pressure","pretty","prevent","previous","previously","price","primary","prime","principle","priority","prison","prisoner","private","probably","problem","procedure","process","produce","product","production","professional","profit","program","programme","progress","project","promise","promote","proper","properly","property","proportion","propose","proposal","prospect","protect","protection","prove","provide","provided","provision","pub","public","public","publication","publish","pull","pupil","purpose","push","put","quality","quarter","question","question","quick","quickly","quiet","quite","race","radio","railway","rain","raise","range","rapidly","rare","rate","rather","reach","reaction","read","reader","reading","ready","real","realise","reality","realize","really","reason","reasonable","recall","receive","recent","recently","recognise","recognition","recognize","recommend","record","record","recover","red","reduce","reduction","refer","reference","reflect","reform","refuse","regard","region","regional","regular","regulation","reject","relate","relation","relationship","relative","relatively","release","release","relevant","relief","religion","religious","rely","remain","remember","remind","remove","repeat","replace","reply","report","report","represent","representation","representative","request","require","requirement","research","resource","respect","respond","response","responsibility","responsible","rest","rest","restaurant","result","result","retain","return","return","reveal","revenue","review","revolution","rich","ride","right","right","right","ring","ring","rise","rise","risk","river","road","rock","role","roll","roof","room","round","round","route","row","royal","rule","run","run","rural","safe","safety","sale","same","sample","satisfy","save","say","scale","scene","scheme","school","science","scientific","scientist","score","screen","sea","search","search","season","seat","second","secondary","secretary","section","sector","secure","security","see","seek","seem","select","selection","sell","send","senior","sense","sentence","separate","separate","sequence","series","serious","seriously","servant","serve","service","session","set","set","settle","settlement","several","severe","sex","sexual","shake","shall","shape","share","share","she","sheet","ship","shoe","shoot","shop",
"short","shot","should","shoulder","shout","show","show","shut","side","sight","sign","sign","signal","significance","significant","silence","similar","simple","simply","since","since","sing","single","sir","sister","sit","site","situation","size","skill","skin","sky","sleep","slightly","slip","slow","slowly","small","smile","smile","so","so","social","society","soft","software","soil","soldier","solicitor","solution","some","somebody","someone","something","sometimes","somewhat","somewhere","son","song","soon","sorry","sort","sound","sound","source","south","southern","space","speak","speaker","special","species","specific","speech","speed","spend","spirit","sport","spot","spread","spring","staff","stage","stand","standard","standard","star","star","start","start","state","state","statement","station","status","stay","steal","step","step","stick","still","stock","stone","stop","store","story","straight","strange","strategy","street","strength","strike","strike","strong","strongly","structure","student","studio","study","study","stuff","style","subject","substantial","succeed","success","successful","such","suddenly","suffer","sufficient","suggest","suggestion","suitable","sum","summer","sun","supply","supply","support","support","suppose","sure","surely","surface","surprise","surround","survey","survive","switch","system","table","take","talk","talk","tall","tape","target","task","tax","tea","teach","teacher","teaching","team","tear","technical","technique","technology","telephone","television","tell","temperature","tend","term","terms","terrible","test","test","text","than","thank","thanks","that","that","the","the","the","the","the","theatre","their","them","theme","themselves","then","theory","there","there","therefore","these","they","thin","thing","think","this","those","though","though","thought","threat","threaten","through","through","throughout","throw","thus","ticket","time","tiny","title","to","to","to","today","together","tomorrow","tone","tonight","too","tool","tooth","top","top","total","total","totally","touch","touch","tour","towards","town","track","trade","tradition","traditional","traffic","train","train","training","transfer","transfer","transport","travel","treat","treatment","treaty","tree","trend","trial","trip","troop","trouble","TRUE","trust","truth","try","turn","turn","twice","type","typical","unable","under","under","understand","understanding","undertake","unemployment","unfortunately","union","unit","united","university","unless","unlikely","until","until","up","up","upon","upper","urban","us","use","use","used","used","useful","user","usual","usually","value","variation","variety","various","vary","vast","vehicle","version","very","very","via","victim","victory","video","view","village","violence","vision","visit","visit","visitor","vital","voice","volume","vote","vote","wage","wait","walk","walk","wall","want","war","warm","warn","wash","watch","water","wave","way","we","weak","weapon","wear","weather","week","weekend","weight","welcome","welfare","well","well","west","western","what","whatever","when","when","where","where","whereas","whether","which","while","while","whilst","white","who","whole","whole","whom","whose","why","wide","widely","wife","wild","will","will","win","wind","window","wine","wing","winner","winter","wish","with","withdraw","within","without","woman","wonder","wonderful","wood","word","work","work","worker","working","works","world","worry","worth","would","write","writer","writing","wrong","yard","yeah","year","yes","yesterday","yet","you","young","your","yourself","youth	"};
        #endregion strings

		public static string GetFirstName()
		{
			return FirstNames[new Random().Next(0, FirstNames.Length - 1)];
		}

		public static string GetLastName()
		{
			return LastNames[new Random().Next(0, LastNames.Length - 1)];
		}

		/// <summary>
		/// Will get a First Last.
		/// </summary>
		/// <returns></returns>
		public static string GetFullName()
		{
			return GetFirstName() + " " + GetLastName();
		}

        public static string GetString(Int32 minLength, Int32 maxLength, bool numericOnly, Int32 maxValue, bool useSpaces)
        {
            


            System.Threading.Thread.Sleep(30);
            StringBuilder valueOutput = new StringBuilder();
            Random rnd = new Random();

            if (!numericOnly)
            {
                int max = rnd.Next(minLength, maxLength);
                int rndNum = 0;
                while (valueOutput.Length < max)
                {
                    rndNum = rnd.Next(0, BUNCH_OF_WORDS.Length - 1);
                    valueOutput.AppendFormat("{0}{1}", BUNCH_OF_WORDS[rndNum], useSpaces ? " " : string.Empty);
                    //if (rnd.Next(0, 100) == 0) valueOutput.Append("</p><p>");
                }
				if (valueOutput.Length > max)
					return valueOutput.ToString().Substring(0, max);
                return valueOutput.ToString();
            }
            else
            {
                Int32 maxNumber = Int32.Parse(new string(Convert.ToChar("9"), maxLength));
                if ((maxValue < maxNumber) && (maxValue > -1))
                {
                    maxNumber = maxValue;
                }
                valueOutput.Append(GetInt(-1, maxNumber).ToString().PadLeft(maxLength, Convert.ToChar("0")));
            }

            return valueOutput.ToString();
        }

        public static string GetBunchOfText(int MaxLength)
        {
            bool paras = true;
            return GetBunchOfText(MaxLength, paras);
        }
        public static string GetBunchOfText(int MaxLength, bool paras)
        {
            StringBuilder sb = new StringBuilder();
            int max = rnd.Next(1, MaxLength);
            int rndNum = 0;
            bool endSentence=false;
            if(paras)sb.Append("<p>");
            while (sb.Length < max)
            {
                if(paras) endSentence = rnd.Next(1, 15) == 1;
                rndNum = rnd.Next(0, BUNCH_OF_WORDS.Length - 1);
                sb.AppendFormat("{0}{1}", BUNCH_OF_WORDS[rndNum], endSentence? BUNCH_OF_PUNCTUATIONS[rnd.Next(0,BUNCH_OF_PUNCTUATIONS.Length-1)] : " ");
                if (paras && rnd.Next(0, 100) == 0) sb.Append("</p><p>");
            }
            if(paras)sb.Append("</p>");
            return sb.ToString();
        }

        public static string[] GetTags(int MaxCount)
        {
            int max = MaxCount == 1 ? 1 : rnd.Next(1, MaxCount);
            string[] ret = new string[max];
            for (int i = 0; i < max; i++)
            {
                ret[i] = BUNCH_OF_TAGS[rnd.Next(0, BUNCH_OF_TAGS.Length - 1)];
            }
            return ret;
        }


        public static Int32 GetInt(Int32 minValue, Int32 maxValue)
        {
            Int32 returnValue;

            System.Threading.Thread.Sleep(1);
            Random rndNum = new Random();

            if (maxValue < 0)
            {
                returnValue = rndNum.Next();
            }
            else if (minValue < 0)
            {
                returnValue = rndNum.Next(maxValue);
            }
            else
            {
                returnValue = rndNum.Next(minValue, maxValue);
            }
            return returnValue;
        }
        public static Int32 GetInt()
        {
            return GetInt(-1, -1);
        }
        public static decimal GetDecimal(int min, int max)
        {
            System.Threading.Thread.Sleep(1);
            Random rndNum = new Random();
            Random rndLeft = new Random();

            return (decimal)(rndLeft.Next(min, max - 1) + rndNum.NextDouble());
        }

		public static decimal GetPrice(int min, int max)
		{
			System.Threading.Thread.Sleep(1);
			Random rndNum = new Random();
			Random rndLeft = new Random();

			var d = (decimal)(rndLeft.Next(min, max - 1) + rndNum.NextDouble());
			return Decimal.Parse(d.ToString("#.##"));
		}
        public static DateTime GetDateTime()
        {
            System.Threading.Thread.Sleep(1);
            Random rndNum = new Random();
            return DateTime.Now.AddMonths(rndNum.Next(-100, 0)).AddMinutes((double)rndNum.Next(-12000, 12000));
        }
        public static Decimal GetDateDecimal()
        {
            System.Threading.Thread.Sleep(1);
            Random rndNum = new Random();
            DateTime currDate = DateTime.Now.AddMonths(rndNum.Next(-100, 0)).AddMinutes((double)rndNum.Next(-12000, 12000));
            string dateNum = currDate.ToString("yyyyMMdd");
            return Convert.ToDecimal(dateNum);
        }
        public static string GetGuid()
        {
            return System.Guid.NewGuid().ToString();
        }
        public static bool GetBool()
        {
            bool boolReturn;

            boolReturn = false;

            System.Threading.Thread.Sleep(1);
            Random rndNum = new Random();
            if (rndNum.Next(1, 100) <= 50)
            {
                boolReturn = true;
            }
            return boolReturn;
        }
        public static string GetPhoneNumber()
        {
            return GetString(3, true) + "-" + GetString(3, true) + "-" + GetString(4, true);
        }
        public static string GetEmail()
        {
			if (new Random().Next(0,1) == 0 )
				return GetFirstName() + "@" + GetString(10, false, false) + ".com";
			else
				return GetFirstName() + "." + GetLastName() + "@" + GetString(10, false, false) + ".com";
        }

        public static string GetURL()
        {
            return "http://www." + GetString(15) + ".com";
        }
        public static string GetAddress()
        {
            return GetAddress(false);
        }

        public static string GetAddress(bool optional)
        {
            string returnValue = string.Empty;

            System.Threading.Thread.Sleep(3);
            Random rndNum = new Random();

            // if the address is optional then only
            // return a value 20% of the time
            if ((optional == false) || (rndNum.Next(100) > 80))
            {
                returnValue = GetString(3, true) + " " + GetString(10) + " " + "Street";
            }

            return returnValue;
        }
        public static string GetImage()
        {
            return GetImage("jpg");
        }
        public static string GetImage(string extension)
        {
            extension = (extension.StartsWith(".") ? string.Empty : ".");
            return "image" + GetInt(1, 5).ToString() + extension;
        }
    }
}
