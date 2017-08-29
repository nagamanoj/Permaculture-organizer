using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using our own class definitions.
using FoodGroupClass;
using FoodSourceClass;
using DishClass;

public partial class ListsListsLists : System.Web.UI.Page
{    
    // Here are some food groups. Each food group also contains a list of food sources, and each
    // food source also contains a list of dishes and each dish also contains a list of 
    // ingredients.
    static FoodGroup fruitGroup, vegetableGroup, grainGroup, mushroomGroup, dairyGroup, meatGroup;    
    // General list of food groups.
    static List<FoodGroup> generalFoodGroupList = new List<FoodGroup>();
    // Food group lists based on classification.
    static List<FoodGroup> plantBasedFoodGroupList = new List<FoodGroup>();
    static List<FoodGroup> fungiBasedFoodGroupList = new List<FoodGroup>();
    static List<FoodGroup> animalBasedFoodGroupList = new List<FoodGroup>();
    // List of lists of food groups based on the food group classification: 
    // plant-based, fungi-based, and animal-based.
    static List<List<FoodGroup>> foodGroupClassificationList = new List<List<FoodGroup>>();
    // Current selected items in GUI.
    static FoodGroup currentFoodGroup;                  // References the current food group.
    static FoodSource currentFoodSource;                // References the current food source.
    static Dish currentDish;                            // References the current dish.
    static List<FoodGroup> currentClassificationList = plantBasedFoodGroupList;   // References the current classification list.
    static FoodGroup currentClassificationFoodGroup;    // References the current classification food group.
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            // Construct food groups, food sources, and dishes.
            constructFoodGroups();
            constructFoodSourcesAndDishes();            
            // Complete initialization of lists.
            addFoodGroupsToGeneralList();           // Place food groups into general food group.
            addFoodGroupsToClassificationLists();   // Place food groups into food classification lists.
            addClassificationListsToList();         // Add classification lists to list.                

            // Establish the current food group and populate foodGroupListBox.
            bool firstGroup = true;
            foodGroupListBox.Items.Clear();
            foreach (FoodGroup group in generalFoodGroupList)
            {
                foodGroupListBox.Items.Add(new ListItem(group.Name));
                if (firstGroup)  // Select first item added to the list.
                {           // Add set dependent values in ASP.NET controls appropriately.
                    currentFoodGroup = group;
                    firstGroup = false;
                }
            }
            // Initialize lists data in foodGroupListBox and follow up with connected controls.
            updateFoodGroupGUI();

            // Initialize drop down options for lists of lists and dependent UI components.   
            foodGroupClassificationDropDownList.Items.Clear();
            foodGroupClassificationDropDownList.Items.Add(new ListItem("Plant-based food groups"));
            foodGroupClassificationDropDownList.Items.Add(new ListItem("Fungi-based food groups"));
            foodGroupClassificationDropDownList.Items.Add(new ListItem("Animal-based food groups"));
            // Initialize GUI for food group classification data.            
            updateFoodGroupClassificationGUI();
        }        
    } // End Page_Load method.

    protected void foodGroupListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Determine current selected item and update GUI based on selection.
        foreach (FoodGroup group in generalFoodGroupList)
        {
            if (foodGroupListBox.SelectedItem.Text.Equals(group.Name))
            {
                currentFoodGroup = group;
            }            
        }
        updateFoodGroupGUI();
    }   
    
    protected void updateFoodGroupGUI()
    {
        // Set GUI attributes for currentFoodGroup item. 
        foodGroupImage.ImageUrl = "Images/" + currentFoodGroup.ImageFileName;
        foodGroupTextBox.Text = currentFoodGroup.Description;                
        // Add food sources for selected food group.
        bool firstSource = true;
        foodSourceListBox.Items.Clear();
        // Determine current default selected first item and update GUI based on selection.
        foreach (FoodSource source in currentFoodGroup.List)
        {
            foodSourceListBox.Items.Add(source.Name);
            if (firstSource)
            {                
                currentFoodSource = source;
                firstSource = false;                             
            }
        }
        updateFoodSourceGUI();
    }

    protected void foodSourceListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Determine current selected item and update GUI based on selection.
        foreach (FoodSource source in currentFoodGroup.List)
        {
            if (foodSourceListBox.SelectedItem.Text.Equals(source.Name))
            {
                currentFoodSource = source;
            }            
        }
        updateFoodSourceGUI();
    }

    protected void updateFoodSourceGUI()
    {
        foodSourceImage.ImageUrl = "Images/" + currentFoodSource.ImageFileName;
        foodSourceTextBox.Text = currentFoodSource.Description;
        // Add dishes to the selected food source.        
        // Determine current default selected first dish and update GUI based on selection.
        bool firstDish = true;
        dishListBox.Items.Clear();
        foreach (Dish dish in currentFoodSource.List)
        {
            // Add all dishes to list box.
            dishListBox.Items.Add(dish.Name);
            if (firstDish)
            {                
                firstDish = false;
                currentDish = dish;
            }
        }
        updateDishGUI();
    }

    protected void dishListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Determine current selected item and update GUI based on selection.
        foreach (Dish dish in currentFoodSource.List)
        {
            if (dishListBox.SelectedItem.Text.Equals(dish.Name))
            {                
                currentDish = dish;
            }
        }
        updateDishGUI();
    }

    protected void updateDishGUI()
    {
        dishImage.ImageUrl = "Images/" + currentDish.ImageFileName;
        dishTextBox.Text = currentDish.Description;
    }

    protected void foodGroupClassificationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Determine current selected item and update GUI based on selection.                  
        if (foodGroupClassificationDropDownList.SelectedIndex == 1)                
        {
            currentClassificationList = fungiBasedFoodGroupList;            
        }
        else if (foodGroupClassificationDropDownList.SelectedIndex == 2)
        {
            currentClassificationList = animalBasedFoodGroupList;
        }
        else
        {
            currentClassificationList = plantBasedFoodGroupList;
        } 
        updateFoodGroupClassificationGUI();
    }

    protected void updateFoodGroupClassificationGUI()
    {
        // Clear values in list box and then fill values.        
        bool first = true;
        foodGroupListListBox.Items.Clear();
        foreach (FoodGroup group in currentClassificationList)
        {
            foodGroupListListBox.Items.Add(group.Name);
            if (first)
            {
                // Update connected controls based on default first group value.
                foodGroupListListBox.Items.FindByValue(group.Name).Selected = true;
                foodGroupInClassificationImage.ImageUrl = "Images/" + group.ImageFileName;
                first = false;
            }
        }
    }

    protected void foodGroupListListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Set currentClassificationFoodGroup and update GUI based on that value.
        foreach (FoodGroup group in generalFoodGroupList)
        {
            if (foodGroupListListBox.SelectedItem.Text.Equals(group.Name))
            {
                currentClassificationFoodGroup = group;
            }
        }
        foodGroupInClassificationImage.ImageUrl = "Images/" + currentClassificationFoodGroup.ImageFileName;
    }
        
    // Methods to initialize lists and list data:

    // Place food groups into general food group.
    protected void addFoodGroupsToGeneralList()
    {
        generalFoodGroupList.Clear();
        generalFoodGroupList.Add(fruitGroup);
        generalFoodGroupList.Add(vegetableGroup);
        generalFoodGroupList.Add(grainGroup);
        generalFoodGroupList.Add(mushroomGroup);
        generalFoodGroupList.Add(dairyGroup);
        generalFoodGroupList.Add(meatGroup);
    }

    // Construct food group objects. 
    protected void constructFoodGroups()
    {
        fruitGroup = new FoodGroup("Fruits", "The fruit group includes citrus, stone fruits, berries, grapes, figs, dates, ...", "FruitsFrom100DaysWithoutSweets.png");
        vegetableGroup = new FoodGroup("Vegetables", "The vegetable group is comprised of many plants from many families including the cabbage, daisy, grass, mallow, beetroot, marrow, legume, potato, ... families.", "VegetableGardenFromVegetableGardenHub.jpg");
        grainGroup = new FoodGroup("Grains", "The grain group of foods are the staple foods of agriculture-based societies.", "GrainsFromEstrildid.jpg");
        mushroomGroup = new FoodGroup("Mushrooms", "The mushrooms food group includes fleshy, spore-bearing fruiting body of fungi. While many mushrooms are edible, great care must be taken when collecting mushrooms in the wild because many mushrooms are poisonous and it is often difficult to differentiate between mushroom species.", "MushroomsFromVarietiesOfEdibleMushrooms.jpg");
        dairyGroup = new FoodGroup("Dairy", "The dairy group includes eggs and milk as well as products derived from them. These foods are naturally linked to the nutritional needs of newly hatched or born individuals.", "DairyFromInternationalDairyFoodAssociation.jpg");
        meatGroup = new FoodGroup("Meat", "The meat group is comprised of foods that are very high in protein. Not all people or cultures choose to eat from this group.", "MeatsFromFanPop.jpg");
    }

    protected void constructFoodSourcesAndDishes()
    {
        // 1. Create FoodSource objects. 2. Add to FruitGroup. 3. Include dishes.
        // Fruit group.
        FoodSource temp = new FoodSource("Apple tree", "An fruit tree in the rose family.", "AppleTreeFromTreemendousFruit.jpg"); // 1. Create ...
        fruitGroup.Add(temp); // 2. Add to ...
        temp.Add(new Dish("Apple pie", "Apple pie is a traditional fruit pie whose principal filling ingredient is apples. Especially during holidays it is served with ice cream on top.", "ApplePieFromStagetecture.jpg")); // 3. Include ... 
        temp.Add(new Dish("Apple walnut gorgonzola turnovers", "A baked turn-over made from apples, walnuts, gorgonzola, thyme, and honey.", "AppleWalnutGorgonzolaTurnoversFromSimplyRecipes.jpg")); // 3. Include ... 
        // More FoodSource objects.
        temp = new FoodSource("Lemon tree", "A citrus tree with a sour fruit that is rich in vitamin C.", "LemonTreeFromShilveryInc.jpg"); // 1. Create ...
        fruitGroup.Add(temp); // 2. Add to ...
        temp.Add(new Dish("Lemonade", "Jake's Lemonade is a home grown recipe, made from all fresh ingrediants.", "LemonadeFromJakesLemonage.jpg")); // 3. Include ... 
        temp.Add(new Dish("Grandmother's sugar lemon cookies", "Traditional lemon cookies from an old recipe", "LemonSugarCookieFromPinterest.jpg")); // 3. Include ... 
        // Vegetable group.
        temp = new FoodSource("Bok choy", "A green grown in China of the cabbage family.", "BokChoyFromAmazon.jpg"); // 1. Create ...
        vegetableGroup.Add(temp); // 2. Add to .....
        temp.Add(new Dish("Bok choy and shrimp", "A salad made bok choy and shrimp.", "BokChoyShrimpFromRecipe_com.jpg")); // 3. Include ... 
        Dish tempDish = new Dish("Baby bok choy with mushrooms", "A Bok choy dish with mushrooms, garlic, and tasty sauces.", "Bok-choy-with-mushroomFromDishMap.Com.jpg");
        temp.Add(tempDish); // 3. Include ... 
        // Mushroom group.
        temp = new FoodSource("White button fungi", "The white button mushroom is a commonly eaten mushrooms. It can be eaten raw or cooked with soups, salads, and pizzas.", "MushroomFromEpicurious.jpg"); // 1. Create ...        
        mushroomGroup.Add(temp);        
        temp.Add(tempDish); // 3. Include ... 
        temp = new FoodSource("Shiitake mushroom", "Shiitake mushrooms have a light flavor and aroma and are high in protein.", "ShitakeMushroomFromEpicurious.jpg");
        mushroomGroup.Add(temp);
        tempDish = new Dish("Flatbread with Fingerling Potatoes, Shitake Mushrooms, and Truffle Oil", "A delicious flatbread recipe with shiitake mushrooms.", "ShiitakeDishFromEpicurious.jpg");
        temp.Add(tempDish); 
        // Grain group.
        temp = new FoodSource("Wheat", "Wheat is a cereal grain originally cultivated in the Levant region of the Near East. It is now cultivated in much of the world.", "WheatFromICInternational.jpg"); 
        grainGroup.Add(temp);
        temp.Add(tempDish);
        temp = new FoodSource("Rice", "Rice is a cereal grain. It is a staple food for a large part of the world's human population.", "RiceFrom123rf.jpg");
        grainGroup.Add(temp);
        tempDish = new Dish("Cheesy Tuna and Rice Dish", "Cheesy Tuna and Rice Dish is an easy and scrumptious variation on the traditional casserole.", "TunaRiceCheeseFromVeryBestBaking.jpg");
        temp.Add(tempDish);         
        // Meat group.
        temp = new FoodSource("Bluefin Tuna", "Bluefin tuna are saltwater fish in the mackerel family. They grow to over six feet long and can live over 50 years.", "BluefinTunaFromMarineBio.jpg");
        meatGroup.Add(temp);
        temp.Add(tempDish);         
        // Dairy group.
        temp = new FoodSource("Chicken egg", "Chicken eggs are used widely throughout most of the world for cooking. The egg yolks store significant amounts of protein and choline.", "ChickenEggsFromBackyardChickens.jpg");
        dairyGroup.Add(temp);
        temp.Add(new Dish("Classic egg salad", "This creamy egg salad includes lettuce and onions and is often added to sandwich bread.", "EggSaladFromIncredibleEgg.jpg"));
        //new FoodSource("Bell pepper or capsicum", "", "CapsicumFromAgrifarming.png");
    }

    // Place food groups into food classification lists.
    protected void addFoodGroupsToClassificationLists()
    {
        plantBasedFoodGroupList.Clear();
        plantBasedFoodGroupList.Add(fruitGroup);
        plantBasedFoodGroupList.Add(vegetableGroup);
        plantBasedFoodGroupList.Add(grainGroup);
        fungiBasedFoodGroupList.Clear();
        fungiBasedFoodGroupList.Add(mushroomGroup);
        animalBasedFoodGroupList.Clear();
        animalBasedFoodGroupList.Add(dairyGroup);
        animalBasedFoodGroupList.Add(meatGroup);        
    }
    
    // Add classification lists to list.    
    protected void addClassificationListsToList()
    {
        foodGroupClassificationList.Clear();
        foodGroupClassificationList.Add(plantBasedFoodGroupList);
        foodGroupClassificationList.Add(fungiBasedFoodGroupList);
        foodGroupClassificationList.Add(animalBasedFoodGroupList);
    }
    
}
