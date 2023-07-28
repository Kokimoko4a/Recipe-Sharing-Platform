using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingPlatform.Data.Migrations
{
    public partial class AddedNewPropertyAndSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CookingTypes",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A multicooker (also written multi cooker) is an electric kitchen appliance for automated cooking using a timer. A typical multicooker is able to boil, simmer, bake, fry, deep fry, grill roast, stew, steam and brown food.The device is operated by placing ingredients inside, selecting the corresponding program, and leaving the multicooker to cook according to the program, typically without any need for further user intervention. Some multicookers have an adjustable thermostat.In addition to cooking programs, a multicooker may have functions to keep food warm, reheat it or to cook it at a later time. Some multicookers can also function as slow cookers.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "A slow cooker, also known as a crock-pot (after a trademark owned by Sunbeam Products but sometimes used generically in the English-speaking world), is a countertop electrical cooking appliance used to simmer at a lower temperature than other cooking methods, such as baking, boiling, and frying. This facilitates unattended cooking for many hours of dishes that would otherwise be boiled: pot roast, soups, stews and other dishes (including beverages, desserts and dips).");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Baking is a method of preparing food that uses dry heat, typically in an oven, but can also be done in hot ashes, or on hot stones. The most common baked item is bread, but many other types of foods can be baked. Heat is gradually transferred from the surface of cakes, cookies, and pieces of bread to their center. As heat travels through, it transforms batters and doughs into baked goods and more with a firm dry crust and a softer center\".[2] Baking can be combined with grilling to produce a hybrid barbecue variant by using both methods simultaneously, or one after the other. Baking is related to barbecuing because the concept of the masonry oven is similar to that of a smoke pit.Baking has traditionally been performed at home for day-to-day meals and in bakeries and restaurants for local consumption. When production was industrialized, baking was automated by machines in large factories. The art of baking remains a fundamental skill and is important for nutrition, as baked goods, especially bread, are a common and important food, both from an economic and cultural point of view. A person who prepares baked goods as a profession is called a baker. On a related note, a pastry chef is someone who is trained in the art of making pastries, cakes, desserts, bread, and other baked goods.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Blanching is a cooking process in which a food, usually a vegetable or fruit, is scalded in boiling water, removed after a brief, timed interval, and finally plunged into iced water or placed under cold running water (known as shocking or refreshing) to halt the cooking process. Blanching foods helps reduce quality loss over time. Blanching is often used as a treatment prior to freezing, drying, or canning—heating vegetables or fruits to inactivate enzymes, modify texture, remove the peel, and wilt tissue. The inactivation of enzymes preserves color, flavor, and nutritional value. The process has three stages: preheating, blanching, and cooling. The most common blanching methods for vegetables/fruits are hot water and steam, while cooling is either done using cold water or cool air. Other benefits of blanching include removing pesticide residues and decreasing microbial load. Drawbacks to the blanching process can include leaching of water-soluble and heat sensitive nutrients and the production of effluent.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Boiling is the rapid phase transition from liquid to gas or vapor; the reverse of boiling is condensation. Boiling occurs when a liquid is heated to its boiling point, when the temperature at which the vapour pressure of the liquid is equal to the pressure exerted on the liquid by the surrounding atmosphere. Boiling and evaporation are the two main forms of liquid vapourization. There are two main types of boiling: nucleate boiling where small bubbles of vapour form at discrete points, and critical heat flux boiling where the boiling surface is heated above a certain critical temperature and a film of vapour forms on the surface. Transition boiling is an intermediate, unstable form of boiling with elements of both types. The boiling point of water is 100 °C or 212 °F but is lower with the decreased atmospheric pressure found at higher altitudes. Boiling water is used as a method of making it potable by killing microbes and viruses that may be present. The sensitivity of different micro-organisms to heat varies, but if water is held at 100 °C (212 °F) for one minute, most micro-organisms and viruses are inactivated. Ten minutes at a temperature of 70 °C (158 °F) is also sufficient to inactivate most bacteria. Boiling water is also used in several cooking methods including boiling, steaming, and poaching.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "A stew is a combination of solid food ingredients that have been cooked in liquid and served in the resultant gravy. Ingredients can include any combination of vegetables and may include meat, especially tougher meats suitable for slow-cooking, such as beef, pork, venison, rabbit, lamb, poultry, sausages, and seafood. While water can be used as the stew-cooking liquid, stock is also common. A small amount of red wine or other alcohol is sometimes added for flavour. Seasonings and flavourings may also be added. Stews are typically cooked at a relatively low temperature (simmered, not boiled), allowing flavours to mingle. Cocido montañés or Highlander stew, a common Cantabrian dish Stewing is suitable for the least tender cuts of meat that become tender and juicy with the slow moist heat method. This makes it popular for low-cost cooking. Cuts with a certain amount of marbling and gelatinous connective tissue give moist, juicy stews, while lean meat may easily become dry. Stews are thickened by reduction or with flour, either by coating pieces of meat with flour before searing, or by using a roux or beurre manié, a dough consisting of equal parts fat and flour. Thickeners like cornstarch, potato starch, or arrowroot may also be used.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Flour breadings, i.e., coatings that are not thermally processed, create an uneven, home-style appearance. The majority of them contain flour from grains. Most of these breadings consist of wheat flour; however, rice flour, corn flour, and malted barley flour may also be used. In addition, grain-flour breadings might contain other ingredients, including starches, gums, food fibers, chemical leaveners, coloring agents, and seasonings. Nongrain-flour breadings, such as soy, potato, water chestnut, manioc, and almond, are usually used for value-added applications or to allow certain claims, such as low-carbohydrate, special texture, gluten-free, or other health considerations.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Sautéing or sauteing (UK: /ˈsoʊteɪɪŋ/, US: /soʊˈteɪɪŋ, sɔː-/; from French sauté [sote] 'jumped, bounced' in reference to tossing while cooking) is a method of cooking that uses a relatively small amount of oil or fat in a shallow pan over relatively high heat. Various sauté methods exist.Ingredients for sautéing are usually cut into small pieces or thinly sliced to provide a large surface area, which facilitates fast cooking. The primary mode of heat transfer during sautéing is conduction between the pan and the food being cooked. Food that is sautéed is browned while preserving its texture, moisture, and flavor. If meat, chicken, or fish is sautéed, the sauté is often finished by deglazing the pan's residue to make a sauce. Sautéing may be compared with pan frying, in which larger pieces of food (for example, chops or steaks) are cooked quickly in oil or fat, and flipped onto both sides. Some cooks make a distinction between the two based on the depth of the oil used, while others use the terms interchangeably. Sautéing differs from searing in that searing only browns the surface of the food. Certain oils should not be used to sauté due to their low smoke point. Clarified butter, rapeseed oil and sunflower oil are commonly used for sautéing; whatever the fat, it must have a smoke point high enough to allow cooking on medium-high heat, which is the temperature at which sautéing is done. For example, although regular butter would impart more flavor, it would also burn at a lower temperature and more quickly than other fats due to the presence of milk solids. Clarified butter is more fit for this use.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: " microwave oven (commonly referred to as a microwave) is an electric oven that heats and cooks food by exposing it to electromagnetic radiation in the microwave frequency range.[1] This induces polar molecules in the food to rotate and produce thermal energy in a process known as dielectric heating. Microwave ovens heat foods quickly and efficiently because excitation is fairly uniform in the outer 25–38 mm (1–1.5 inches) of a homogeneous, high-water-content food item. The development of the cavity magnetron in the United Kingdom made possible the production of electromagnetic waves of a small enough wavelength (microwaves). American engineer Percy Spencer is generally credited with inventing the modern microwave oven after World War II from radar technology developed during the war. Named the \"Radarange\", it was first sold in 1946. Raytheon later licensed its patents for a home-use microwave oven that was introduced by Tappan in 1955, but it was still too large and expensive for general home use. Sharp Corporation introduced the first microwave oven with a turntable between 1964 and 1966. The countertop microwave oven was introduced in 1967 by the Amana Corporation. After microwave ovens became affordable for residential use in the late 1970s, their use spread into commercial and residential kitchens around the world, and prices fell rapidly during the 1980s. In addition to cooking food, microwave ovens are used for heating in many industrial processes. Microwave ovens are a common kitchen appliance and are popular for reheating previously cooked foods and cooking a variety of foods. They rapidly heat foods which can easily burn or turn lumpy if cooked in conventional pans, such as hot butter, fats, chocolate or porridge. Microwave ovens usually do not directly brown or caramelize food, since they rarely attain the necessary temperature to produce Maillard reactions. Exceptions occur in cases where the oven is used to heat frying-oil and other oily items (such as bacon), which attain far higher temperatures than that of boiling water.[citation needed] Microwave ovens have a limited role in professional cooking, because the boiling-range temperatures of a microwave oven does not produce the flavorful chemical reactions that frying, browning, or baking at a higher temperature produces. However, such high heat sources can be added to microwave ovens in the form of a convection microwave oven.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Steaming is a method of cooking using steam. This is often done with a food steamer, a kitchen appliance made specifically to cook food with steam, but food can also be steamed in a wok. In the American southwest, steam pits used for cooking have been found dating back about 5,000 years. Steaming is considered a healthy cooking technique that can be used for many kinds of foods. Because steaming can be achieved by heating less water or liquid, and because of the excellent thermodynamic heat transfer properties of steam, steaming can be as fast, or faster, than cooking in boiling water, as well as being more energy efficient.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Grilling is a form of cooking that involves heat applied to the surface of food, commonly from above, below or from the side. Grilling usually involves a significant amount of direct, radiant heat, and tends to be used for cooking meat and vegetables quickly. Food to be grilled is cooked on a grill (an open wire grid such as a gridiron with a heat source above or below), using a cast iron/frying pan, or a grill pan (similar to a frying pan, but with raised ridges to mimic the wires of an open grill). Heat transfer to the food when using a grill is primarily through thermal radiation. Heat transfer when using a grill pan or griddle is by direct conduction. In the United States, when the heat source for grilling comes from above, grilling is called broiling. In this case, the pan that holds the food is called a broiler pan, and heat transfer is through thermal radiation. Direct heat grilling can expose food to temperatures often in excess of 260 °C (500 °F). Grilled meat acquires a distinctive roast aroma and flavor from a chemical process called the Maillard reaction. The Maillard reaction only occurs when foods reach temperatures in excess of 155 °C (310 °F). Studies have shown that cooking beef, pork, poultry, and fish at high temperatures can lead to the formation of heterocyclic amines, benzopyrenes, and polycyclic aromatic hydrocarbons, which are carcinogens. Marination may reduce the formation of these compounds.[6] Grilling is often presented as a healthy alternative to cooking with oils, although the fat and juices lost by grilling can contribute to drier food.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "A frying pan, frypan, or skillet is a flat-bottomed pan used for frying, searing, and browning foods. It is typically 20 to 30 cm (8 to 12 in) in diameter with relatively low sides that flare outwards, a long handle, and no lid. Larger pans may have a small grab handle opposite the main handle. A pan of similar dimensions, but with less flared, more vertical sides and often with a lid, is called a sauté pan. While a sauté pan can be used as a frying pan, it is designed for lower heat cooking.");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "An oven is a tool which is used to expose materials to a hot environment. Ovens contain a hollow chamber and provide a means of heating the chamber in a controlled way. In use since antiquity, they have been used to accomplish a wide variety of tasks requiring controlled heating. Because they are used for a variety of purposes, there are many different types of ovens. These types differ depending on their intended purpose and based upon how they generate heat. Ovens are often used for cooking, where they can be used to heat food to a desired temperature. Ovens are also used in the manufacturing of ceramics and pottery; these ovens are sometimes referred to as kilns. Metallurgical furnaces are ovens used in the manufacturing of metals, while glass furnaces are ovens used to produce glass. There are many methods by which different types of ovens produce heat. Some ovens heat materials using the combustion of a fuel, such as wood, coal, or natural gas, while many employ electricity. Microwave ovens heat materials by exposing them to microwave radiation while electric ovens and electric furnaces heat materials using resistive heating. Some ovens use forced convection, the movement of gases inside the heating chamber, to enhance the heating process, or, in some cases, to change the properties of the material being heated, such as in the Bessemer method of steel production.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CookingTypes");
        }
    }
}
