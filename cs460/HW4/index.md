---
title: "Welcome to Homework 4"
layout: default
---

## Homework 4
This assignment tasked us with learning how to make our own local web application using ASP.NET/MVC 5, with c# as the codebase. In addition to learning and understanding Model/View/Controller functionalality we had to customized mulitple pages using GET/POST API calls.  Mostly we had to learn how to update Controllers that would utilize methods and provide Views when specific actions were performed by a user.  This assignement proved most challenging so I took the opportunity to work with some of my peers to tackle some of the more complex components.  Doing so allowed me to work through the challenges and successfully pull it all together.   

## Links
1. [Assignment Page](https://www.wou.edu/~morses/classes/cs46x/assignments/HW4_1819.html)
2. [Code Repository for HW4](https://github.com/avickers17/avickers17.github.io/tree/master/cs460/HW4)

## Want to go back?
* Back to my Homepage: [Homepage](https://avickers17.github.io)
* Back to my Homework Page: [Homework](https://avickers17.github.io/cs460/)

### Homepage (Updated View)
The first task we had to work on was to update the homepage with new information, links, and updated buttons that were specifically set to our new pages that we were creating.  This was the easiest task as we simply had to update the view page.  This view page was default set to index as far as the view name and controller method call. Once we updated the content, we just had to update the links in the navbar (which was stored in a different shared view, this allowed for all pages to share the navbar and other elements) to match our new paths.  Overall this task was easily accomplished.

Example below:
```html
@*Updated home page based on homework details and requirements*@
<div class="jumbotron">
    <h1>CS 460 Homework 4</h1>
    <p class="lead">
        A few forms and some simple server-side logic -- learning the basics of 
		GET, POST, query strings, from data and handling it all from an
        ASP.NET MVC 5 application.
    </p>
    <p><a href="http://localhost:52737/" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
```

### Convert Miles to Metric (View and Controller Updates Using GET)
The next task required us to create a new page called Converter.  The concept was a page that would simply convert miles to metric (variations of metric aka centimeters, kilometers, etc...) by accepting a numeric value from the user and a radio toggle button. I first put the form together and made sure that the form was connected to the action method converter using the GET method.  This would send the user input back through the query string in a new get request.  I then updated my converter method in my controller that would send new information back to the user based on the string results.  I captured the query string information into two string variables.  I used this data to run a math function that did the conversion to metric and used other variables to determine the coversion ratio, and string output information.  I then added this string to a object called ViewBag that would be included int the view method once the GET request was called again.  But this Viewbag information would only be retrieved if the user filled in the miles information.  I further limited the value of the field using html value requirements.

Example of the form HTML:
```hmtl
  <h1>Convert Miles to Metric</h1>
    <div class="row">
        <div class="col-md-6">
            <form action="converter" method="get">
                <lable>
                    Miles</label>
                    <br>
                    <input class="userInput" type="number" step="0.01" name="miles" required>
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    @*Message will show if it has been updated by the functions in the Updated GET Request*@
                    <h4 class="special_message">@ViewBag.message</h4>
</div>
```
Example of math function:
```cs
public double Conversion(string miles, int muliplier)
        {
            double milesUpdate = Convert.ToDouble(miles);
            double kilometers = milesUpdate * 1.609344 * muliplier;
            return kilometers;
        }
```

Example of creating the return string in the controller:
```cs
//calls function to do the math for the conversion and sets the result to a double
            double conversion = Conversion(miles, multiplier);
            string message = "";
            //simply checks if the miles input was more than one
            double check = Convert.ToDouble(miles);

            //create string response with the updated variables
            if (check == 1 || check == 0)
            {
                message = miles + " mile is equal to " + Convert.ToString(conversion) + " " + meters;
            }
            else
            {
                message = miles + " miles is equal to " + Convert.ToString(conversion) + " " + meters;
            }
            //create a viewbag message to send to the user
            ViewBag.message = message;
            }
        //return the view with or without the message based on if the user entered a number for miles
        return View();
    }
```

### Create a New Color (View and Controller Updates using GET/POST)
For this section, we had to create two methods within the controller.  One that simply showed a basic page layout that would ask the user for input to create a color using hexadecimal form. This initial view was a method in the controller that would simply show the basic page and hide some additional Viewbag information.  Once the user put in their input (I created user validation in html that required that the user entered a specific hex format.  I required this by creating a regular expression format: pattern = "#^[0-9A-fa-f]{6}|[0-9A-fa-f]{3}$"} which was an attribute of the text field) they would be presented with boxes that showed their two colors and returned a mix of the two colors chosen.  For the view page, we had to creat these html user fields by using RAZOR helpers. 

Example of RAZOR helpers:
```cs
@*Area to insert form objects using Razor*@
        @using (Html.BeginForm("Create", "Color", FormMethod.Post, new { id = 0, @class = "my form" }))
        {
            @Html.Label("Color", "First Color")
            @Html.TextBox("ColorA", null, htmlAttributes: 
			new { @class = "form-control", required = "required", pattern = "#[0-9A-fa-f]{3,6}"})
            @Html.Label("Color", "Second Color")
            @Html.TextBox("ColorB", null, htmlAttributes: 
			new { @class = "form-control", required = "required", pattern = "#[0-9A-fa-f]{3,6}"})
```

Once the user input their information, instead of a query string being sent back to the controller, the form simply captured the data and sent the information back as a POST initializing a different method in the controller that was assigned specifically as a POST method and looked for two returning strings.  I used these strings captured in the POST method and first convert them to Color objects.  This allowed me to use these objects and adjust their rgb values as integers to make a third color.  I would look at each rgb value, then add them together (making sure that they did not exceed 255, if so simply update that value to 255) capturing 3 new rbg values in which I assigned to a third color object.  Then I reconverted that object back into a string.  I was stumped here however as to how to make the color boxes.  I worked with a classmate who gave me a suggestion to simply insert div objects that would have width and height.  Then to set the background colors of these objects to the colors.  I applied his suggestion and made it to where the objects would not show if the user text fields were null. Once entered, these new boxes would show via Viewbag.show = true.  Then the POST request would return the updated view.

Exaple C# Code below:

```cs
 public ActionResult Create(string colorA, string colorB)
        {
            //capture the strings from the form inputs
            colorA = Request.Form["ColorA"];
            colorB = Request.Form["ColorB"];
            
            //double check to make sure that the fields are filled out
            if (colorA != null && colorB != null)
            {
                //now show additional color boxes
                ViewBag.show = true;
                
                //create 3 Color objects that transform string hex data into numbers that can be adjusted
                Color color1 = ColorTranslator.FromHtml(colorA);
                Color color2 = ColorTranslator.FromHtml(colorB);
                Color color3 = new Color();
```
```cs
color3 = Color.FromArgb(255, red, green, blue);

                //Convert color3 back into a string used for posting
                string colorC = ColorTranslator.ToHtml(color3);

                //now that colors are set, create 3 boxes that have a background of the chosen color combos
                ViewBag.item1 = "width:60px; height: 60px; background:" + colorA + ";";
                ViewBag.item3 = "width:60px; height: 60px; background:" + colorB + ";";
                ViewBag.item5 = "width:60px; height: 60px; background:" + colorC + ";";
            }
            else
            {
                //keeping these at null in case either form section was not filled in correctly and a POST request made
                ViewBag.item1 = null;
                ViewBag.item3 = null;
                ViewBag.item5 = null;
            }
            //Return the view with the updated boxes
            return View();
```

### Final Thoughts and Output
Once completed, I had a working MVC app (excluding the model for the time being) that had two controllers and would pull in views based on GET/POST requests.  This was yet another projecct that came at us at rocket speeds.  While I do love a good challenge, I found that resources for this project were slightly harder to pinpoint, but I worked with my peers and together we found solutions.  With my project up and running, I look forward to taking a deeper dive at the model components that we will be tackling next week.
