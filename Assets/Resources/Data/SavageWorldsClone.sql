BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `SavageWorlds` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`SN`	INTEGER NOT NULL,
	`CustomizerID`	INTEGER NOT NULL,
	`Prefix`	TEXT,
	`Name`	TEXT NOT NULL,
	`Suffix`	TEXT,
	`Description`	TEXT NOT NULL,
	`FlavourText`	TEXT NOT NULL,
	`DropChance`	TEXT,
	`Effects`	TEXT,
	`Additional Info`	TEXT,
	`Weight`	TEXT,
	`Range`	TEXT,
	`Damage`	TEXT,
	`RoF`	TEXT,
	`AP`	TEXT,
	`Min Str`	TEXT,
	`Burst`	TEXT,
	`Shots`	TEXT,
	`AP Rounds`	TEXT,
	`HE Rounds`	TEXT,
	`Cost`	TEXT,
	`Armor`	TEXT,
	`Toughness`	TEXT,
	FOREIGN KEY(`SN`) REFERENCES `Card`(`SN`)
);
INSERT INTO `SavageWorlds` VALUES (1,1,1,'','FIRE AXE','','The perfect tool for getting up close and personal with devastating impact.','What a way to make an entrance!','','','','2','','Str+d8','','','','','','','','300','','');
INSERT INTO `SavageWorlds` VALUES (2,2,1,'','MATCHES','','Wood, phosphorus and a frictional surface combine to quickly reproduce one of mankind''s greatest achievements over and over again.','Keep ''em secret, keep ''em safe.','','','','-','','','','','','','','','','1','','');
INSERT INTO `SavageWorlds` VALUES (3,3,1,'','GLOCK 18C','','A reliable handgun popular with law enforcement and military elite. Boasting a full auto mode that fires 1,200 rounds per minute. This pistol is non-negotiable 9 mm authority.','Is that a machine pistol in your pocket?','','Semi-auto','','4','12/24/48','2d6','1','1','','','19','','','200','','');
INSERT INTO `SavageWorlds` VALUES (4,4,1,'','FIRST AID KIT','','Kit of preparedness to treat most common ailments and wounds.','Medic!','','','+2 Healing','2','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (5,5,1,'','S&W .44 SNUB NOSE','','A classic revolver that gained its reputation due to its precision and power. It hardly ever misfires, and can quickly be concealed in a pocket or waistband.','The gut buster.','','','','3','12/24/48','2d6+1','1','1','','','6','','','200','','');
INSERT INTO `SavageWorlds` VALUES (6,6,1,'','KALASHNIKOV AK-47 (7.62mm)','','Instantly recognized by its wooden stock and banana shaped magazine, this simple yet dependable weapon is the archetypal rifle of insurgents, freedom fighters, and terrorists across the globe.','Start your own reign of terror.','','Auto','','10','24/48/96','2d8+1','3','2','d6','','30','','','450','','');
INSERT INTO `SavageWorlds` VALUES (7,7,1,'','MEDICINAL CHARCOAL','','Mainly used for purification and highly recommended to treat poisoning and overdoses. The microporosity of the material is unsurpassed in terms of absorption.','Good for what ails you.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (8,8,1,'','ARMY BOOTS','','Military style boots honed for foot protection. Perfect for a variety of climates. They may seem clumsy, but the sore truth is that they always come out on top.','These boots are made for walking.','','','','-','','','','','','','','','','200','','');
INSERT INTO `SavageWorlds` VALUES (9,9,1,'','BACKPACK','','Modern man found ergonomic ways to store items. These carry their weight in gold.','Carry more with less effort.','','','','2','','','','','','','','','','50','','');
INSERT INTO `SavageWorlds` VALUES (10,10,1,'','RED LEATHER JACKET','','Candy apple red might not be the best camo, but you''ll thrill them as you kill them.','King of the killing floor.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (11,11,1,'','SKI HELMET','','Some helmets makes you look good, others make you look like a fool. This is the pretty non-bulletproof version.','Protects the thinker.','','50% chance vs. head shot','','5','','','','','','','','','','75','3','');
INSERT INTO `SavageWorlds` VALUES (12,12,1,'','COMBAT KNIFE','','Rumor has it that really good steel comes from Sweden. Well honed, this knife will cut through just about anything.','Now, THIS is a knife.','','','','3','','Str+d4','','','','','','','','50','','');
INSERT INTO `SavageWorlds` VALUES (13,13,1,'','SMALL BOX OF AMMO','','Manufactured precision-made ammunition, stable and able. The best choice for your weapons.','Food for Guns!','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (14,14,1,'','SHOULDER ARMOR','','Both protection and enhancement in one. Makes you look beefed up and adds good protection against any blunt violence.','The slender becomes the wider.','','','','10','','','','','','','','','','100','2','');
INSERT INTO `SavageWorlds` VALUES (15,15,1,'','LIFE JACKET','','Designed to hold a man''s head above water and signal attention with bright color. These well-crafted padded jackets can withstand a punch or two. Keeps you bobbing up most unexpectedly.','Low profile ain''t your thing.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (16,16,1,'','GAS CAN','','Key ingredient for most motorized vehicles, highly flammable and invaluable in the production of improvised incendiary weapons.','Alluring fumes that''ll go to your head.','','','','1','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (17,17,1,'','SPRAY CANS','','Color the world around you or inhale it to see perhaps even greater colors. Unknown duration.','Put some more color into this world.','','','','1','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (18,18,1,'','SHOVEL','','A basic tool refined with enhanced functionality. Can provide shelter, food, escape or discoveries.','Dig in.','','','','2','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (19,19,1,'','DYNAMITE','','Well rolled rods that, despite their size, will make quite an impression.','Do they look sweaty!?','','Each additional stick adds +1 damage and +1" to radius.','MBT','2','5-10-20','2d6','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (20,20,1,'','SMALL STASH','','The alluring glow to the little pile of valuables gives you a happy feeling. Someone’s been collecting. Now, it’s yours to cash in.','Look, a rubber band!','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (21,21,1,'','HARPOON GUN','','Quieter than most projectile weapons and more powerful than a sling shot. Works on land and in water. These are rarely found unmodified.','Not just for for whaling, anymore.','','','','4','5-10-20','2d6','1','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (22,22,1,'','FLASHLIGHT','','Packed with electrical lighting power to cut bright cones through darkness, shake or smack if not working properly.','Let there be light.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (23,23,1,'','WRENCH','','A real nut buster! The last tool a real mechanic would ever heft but still more flexible than everything else in the tool box. Loosen or tighten up - all in one.','Sweat or blood, a tool fit for both trades.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (24,24,1,'','METALLIC LIGHTER','','A fistful of torch. This small item is a true art of engineering, that can fire up under the most dire circumstances.','Click, zip, whoosh... BOOM!','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (25,25,1,'','CHAINSAW','','Gasoline and electric versions exist. Both are very dangerous, but the roar of the gasoline version far outweighs the other in terms of intimidation.','Just add massacre.','','A natural 1 on the Fighting die (regardless of the Wild Die) hits the user instead.','','20','','2d6+4','','','','','','','','200','','');
INSERT INTO `SavageWorlds` VALUES (26,26,1,'','REMINGTON 870','','A trusted pump-action shotgun issued in many variations. Owning one of these will change your life by ending others.','Pack a punch.','','','','8','12/24/48','1-3d6','1','','','','6','','','150','','');
INSERT INTO `SavageWorlds` VALUES (27,27,1,'','BINOCULARS','','Good for spying from great distances. Some models feature zoom lenses or other extras.','Just what you''re looking for...','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (28,28,1,'','U-LOCK','','Always make sure you secure your ride, prisoner or box of supplies thoroughly.','Secure bigger things.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (29,29,1,'','TOBACCO','','For those special moments of personal reflection before or after the slaughter.','There are faster ways than this.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (30,30,1,'','ROPE','','High-quality fabric made to withstand stress and heavy loads. A hiker''s item of choice.','How long is a piece of rope? Now you know.','','','','','','','','','','','','','','','','4');
INSERT INTO `SavageWorlds` VALUES (31,31,1,'','RUNNING SHOES','','Made in faraway lands, by the best of hands. Soft rubber soles, and sturdy leather protection. A perfect fit for healthy feet. You´ll never want to run out of these.','Preferred by sneakers.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (32,32,1,'','FRUIT PLANT','','Requires sun, moisture and human-friendly temperatures for the seeds to grow and bear fruit. Treat it with love. This is one of the few things in this world that actually gives something in return.','Water my world.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (33,33,1,'','M1 COMBAT HELMET','','Might just let you live to declare "That was a close call!".','Let me see your war face!','','50% Chance vs. head shot','','4','','','','','','','','','','200','4','');
INSERT INTO `SavageWorlds` VALUES (34,34,1,'','SLEEPING BAG','','Crafted from lightweight fabrics. Designed to withstand Mother Nature’s shifting temperament. A vital piece of equipment that is highly sought after.','When it''s cold outside and you want to sleep in.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (35,35,1,'','DUCT TAPE','','Highly reliable tech that grapples through stickiness. Can fix most damaged materials and keep it functioning - good enough.','If a strip of this doesn''t fix it, nothing will.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (36,36,1,'','REARVIEW MIRROR','','A fine polished reflective glass is a true multipurpose tool for survivors of all Eras.','Objects may appear closer than they are.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (37,37,1,'','COMPASS','','A precision instrument for safe guidance if you know how to use it.','A force unknown controls this device.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (38,38,1,'','KNEEPADS','','When you have to quickly take a knee for that critical shot, a little bit of padding can help you keep your focus on target.','Down on your knees and feel good about it.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (39,39,1,'','WELDING HELMET','','Block body fluids or splinters, hot or cold stuff. Features a tough visor that''s easy to clean.','Protects your face from ugly marks.','','','','4','','','','','','','','','','100','2','');
INSERT INTO `SavageWorlds` VALUES (40,40,1,'','RING OF KEYS','','People usually keep their valuables locked away. Keys fit into locks. Now just find the matching pairs.','These might be the keys to Another World.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (41,41,1,'','PLASTIC BOTTLES','','Durable, flexible container that holds liquids for survival or attack. They come in a variety of configurations.','More common than fish in the sea.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (42,42,1,'','GAS MASK','','Engineering at its best. It''s made for hazardous environments where respiratory functions would be seriously damaged without filtration.','Smell you later.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (43,43,1,'','PILLBOX','','Created to alter the biological or mental state of the user. They can stop bleeding, treat insanity, induce hallucinations or put men to sleep. Most often they are taken orally, swallowed whole.','Take the blue pill.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (44,44,1,'','CANNED FOOD','','Thin metal container that preserves edibles. Often stacked as a status symbol in special cabinets, they usually contain vegetables or meat. Special tools may be used to open them efficiently.','Beggars can''t be choosers.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (45,45,1,'','FINE HARDBOUND BOOK','','Intellectual property should not to be underestimated. With a book in your hand you might come out as a pundit instead of a bandit.','Someone had a lot to say.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (46,46,1,'','THICK BLANKET','','When the nights and the seasons are against you, hug this one a little tighter.','Cover me!','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (47,47,1,'','SCOTCH','','Comes in many shapes, but once emptied becomes, "the best I ever had."','Liquid courage in the form of single or blended.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (48,48,1,'','CROWBAR','','A solid piece of equipment, well worth its weight. Once you start using it, you can’t be without it.','Need to jimmy that?','','Reach 1','','2','','Str+d4','','','','','','','','10','','');
INSERT INTO `SavageWorlds` VALUES (49,49,1,'','TRENCHCOAT','','Excellent to conceal contraband on your body, or more mundanely, keep your arms and legs dry in harsh weather conditions.','#Lurktime','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (50,50,1,'','OIL LAMP','','The best substitute for a lamp in any low tech society. Any hardcore prepper''s first choice of light source.','Light your way, old style.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (51,51,1,'','GLASSES OF SEEING','','Glasses come in all forms and shapes but they most often make you look like someone not to hit in the face.','Put these on and a new world might be revealed.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (52,52,1,'','WATER FLASK','','For longer journeys you always need a reliable container. Never miss a chance to fill ''er up!','Bring your own drink to the party.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (53,53,1,'','FIRE EXTINGUISHER','','Pressure filled canister for dousing flames in awkward places. Can kill a fire in a blink of an eye if handled properly.','Always aim for the base.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (54,54,1,'','ROADSIGN SHIELD','','A punched lightweight sheet of metal, bendable, but sturdy as well. Found everywhere, usually perforated and corroded, but one or two in mint condition is a real haul.','Fast protection against furious forces.','','+1 Parry. +2 Armor to ranged shots that hit.','','12','','','','','','','','','','0','','');
INSERT INTO `SavageWorlds` VALUES (55,55,1,'','BB GUN','','Pneumatic guns are fun to play with, but when you''re facing something bigger than a rat, run!','Aim for the eyes!','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (56,56,1,'','DRY RATION','','Work up some good saliva before you take a bite out of this. The Lembas bread of the future does not come with anything but as a filler of empty stomachs.','It tastes something vague.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (57,57,1,'','FIELD DRESSING','','Sterile compress, everything you need to stop serious bleeding.','Only break the sealing when you really have to.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (58,58,1,'','FISHING GEAR','','Getting in tune with nature, biding time in silence in contrast to the actual catching is what it''s all about.','Wait for it, wait...','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (59,59,1,'','HOME MADE 22','','Home made weapons should always be handled with the utmost respect, with the safety always off you don''t want to put this loaded piece down your waistline.','Jerk, load, shoot in that order.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (60,60,1,'','Hoodie','','The heavy fabric has a life of its own, made for dousing off some place safe.','Looks warmer than it is.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (61,61,1,'','Rusty Kitchen Knife','','You most often find useful tools in what used to be called kitchens.','No cutting boards around.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (62,62,1,'','Pocket Knife','','An ancient pocket knife with wooden handle and carbon steel blade, all you''ll ever need. No?','No excuse for having dirty finger nails.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (63,63,1,'','Toilet rail mace','','Most commonly found near senior villages and often the most basic weapon for hooligans.','Made to be held.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (64,64,1,'','Scarf','','Fashion-statement, political identification, cleaning rag, unwrapped carrying container. This long, broad piece of fabric has many uses...','A garment without a uniform meaning.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (65,65,1,'','Slingshot','','Silent, cheap and effective all in one, never leave you crib without it.','Suddenly the ground is littered with ammunition.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (66,66,1,'','Snare Trap','','Look at the patterns, use bait and lure the little ones into it. Not for anything bigger than rabbits.','For the little critters.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (67,67,1,'','Sweat Pants','','Feel every bit as cozy and free wearing these. Not very tough but more comfy than any leg wear out there.','A constant reminder to relax.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (68,68,1,'','T-shirt','','In the old world there seems to have been many tribes, all with different','The meaning of the print is long forgotten.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (69,69,1,'','Cans of Water','','Emergency water with some extra iron to it. Do not shake. A recommendation would be to poor this one like a good ale and let it rest for a good while.','It''s never enough.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (70,70,1,'','Wind Jacket','','It''s like wearing nothing with holes in it. Once, (when without holes) this must have been something extra special.','At the right angle this one still works.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (71,71,1,'','Worn Boots','','If you run out of ammo just throw these at the enemy, the stench might catch them off guard.','A few more miles in ''em.','','','','','','','','','','','','','','','','');
INSERT INTO `SavageWorlds` VALUES (72,72,1,'','Worn Trousers','','It''s hard to tell what kind of material these are made out of, but as you stretch you can tell they''re not made for any tip-tap shit.','The stains keep these together','','','','','','','','','','','','','','','','');
COMMIT;
