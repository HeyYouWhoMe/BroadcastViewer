# Who™ Me Broadcast Viewer
Who™ Me is presently in it's pre-release phase, but as you can see by the activity here, it is imminwent!

# ```Create your very own Companion App to install alongside the Who™ Me app!```

* The `eventhubdemo` branch of the codebase is presented as a demonstration of how to very easily _firehose_ Who™ Me macro data _directly from the app, straight into a Microsoft Azure Event Hub_ using your very own companion app that you install along-side the Who™ Me app. 

* Because if we are going to make money, so should you!

* Although this app demonstrates the Microsoft Event Hub, you can very easily adapt this tutorial to suit any event hub world-wide, or even one that you create yourself!

# Overview

Event Hubs are a special type of cloud and are designed to accept astronomical amounts of parallel data sets being (to use the official word) 'ingressed' into the event hub in parallel. 

Imagine every drone worldwide reporting it's name, position, altitude, id, barometric pressure, and a timestamp, every second, and you will get the gist about the immense parallel ingest demands that event hubs cater for! 

A variation of the back-end to this event hub was demonstrated by the author and his team, a few years ago at a Microsoft Event Hub Hackathon, at Reading in the UK, which is one of the UK's many 'Silicon Valley' regions. 

What is totally new, here, is how the drone and remote pilot report this information to the Event Hub endpoints that have been previously demonstrated.

_Here, you are going to create a Custom Who™ Me Proximity Persona that you can share to install on any Who™ Me installation, and then you are going to create your very own Companion App that you can install on any device alongside the Who™ Me app so that you can use Who™ Me to drive your own business forwards. We are using a generic case as an example of whatever you can dream up._

_In this illustration-by-example, we are going to create a ```Custom Proximity Persona™``` to track a drone in real time, using a data-set that satisfies the new United States ```FAA Gudelines``` for ```Unmanned aircraft systems traffic management```._

Although we are creating this as a Custom Proximity Profile, you will notice that it already exists as a Well-Known Proximity Profile.

The existing persona has a GUID (Globally Unique Identifier) of ```5d7944fb-bf62-4b6a-addd-d5ec176805ab```, however the benefit of you creating your own custom persona for this project, is that only you and your drone will have it installed. Your Custom Persona will have it's own GUID, and Who™ Me works by broadcasting local URLs. 

_For example, the Well-Known Persona mentioned above broadcasts a URL of ```5d7944fb-bf62-4b6a-addd-d5ec176805ab._whome._tcp._local```, and yet your Custom Persona will broadcast a URL of ```Another_GUID._whome._tcp._local```_

There's no need to know these URLs as the device manages them in the background! 

* However it is important to know that every Persona has it's own unique URL, and as Who™ Me matures, it will be these URLs that devices will use to exchange additional information, such as security keys that each device can use to facilitate secure 5G Loopback services!

There are benefits of you reacreating the existing Well-Known Proximity Persona as a Custom Proximity Persona with a different GUID, even if it is just so that you can create a Companion App without being on everyone's radar until you go to market with it! 

Having said that, if everyone ordinarily flies with the existing Well-Known Persona, then - using the technology described in this project - anyone would be able to build either a fixed or portable drone detector. It would be useful, for example, for some organisations to have a big-screen in the office that displayed drone activity in the precinct! Of course, there are other solutions that would satisfy the same outcome, such as pulling a data-feed from a Drone Event Hub and displaying that information as an alternative. As with all things in business, it all comes down to use-cases!

But it is not unreasonable to think that it could be legislated that specific Well-Known Proximity Personas - or specific publicly distributed Custom Proximity Personas - should be broadcast in certain flight zones, such as operating in, or around, airports, or infrastructures such as power stations. 

_Pre-amble aside, once we create this Custom Proximity Profile, which you can use as an example about how to create any other one, we are then going to create a Companion App to install alongside the Who™ Me app, to demonstrate how you can create any of your own Companion Apps to install alongside the Who™ Me app to drive your business forwards!_

# 1. Download the Who™ Me app onto your Android device.

Who™ Me is presently in a private Beta Closed Testing phase but it's public release in the Google Play Store is imminent.

# 2. Create a Custom Proximity Persona™ using the Who™ Me app and then export it as a .whome text file

Select ```Create``` in the Who™ Me app's menu, which will load the ```Create Custom Persona``` Editor.

Decide upon a function and purpose for your ```Custom Proximity Persona™```, so that you can fill out the required fields in the ```Create Custom Persona``` Editor.

Our ```Custom Proximity Persona™``` is going to track a drone in real time, with the purpose of satisfying the preliminary needs of the US FAA's document titled ```"Remote Identification of Unmanned Aircraft Systems"```, dated 31 Dec 2019, and which can be downloaded from https://www.federalregister.gov/documents/2019/12/31/2019-28100/remote-identification-of-unmanned-aircraft-systems 

_You will notice that we created this tutorial the same day that the document was released!_

Pages 122 to 129 give us the data fields that such a system would require to satisfy the ongoing community enquiry about the document, and in our reading of the document, these fields reduce to the following:

* **UAV ID** - the user assigned ID of the drone
* **Control Station Latitude** - the latitude of the remote pilot
* **Control Station Longitude** - the longitude of the remote pilot
* **Control Station Barometric Pressure** - the barometic pressure of the remote pilot
* **UAV Latitude** - the drone latitude
* **UAV Longitude** - the drone longitude
* **UAV Barometric Pressure** - the drone barometric pressure
* **Time Stamp** - a stamp of time that represents when the readings were current
* **UAV Emergency Status** - and indication of the drone either being in a normal state, or in some other, state

We are going to be clever here, because we notice that both pilot and drone have the following common data-fields:

* Latitude
* Longitude
* Barometirc Pressure

This means that we can create TWO ```Custom Proximity Personas```, one for the pilot, and one for the drone, and by independantly firehosing the data of each straight into the same Azure Event Hub, we can join them both together by adding a common ```Flight Number``` field.

To make this demonstration easier, we will concentrate on just creating the ```Custom Proximity Profile™``` and ```Companion App``` for the drone. 

As homework, all you need to do is replicate exactly the same steps for the pilot as you do here for the drone, because satisfying the FAA's requirements will be a matter of how to get the common information **out** of the Event Hub and directing it to a common, official, ```FAA Traffic Management Aggregator``` so that information about all drones are commonly available to any service that needs it. 

So for now, let's concentrate on the drone!

## a. Create the Persona Title

Let's call the Custom Proximity Persona what it is, naming it ```FAA Compliant UAV Traffic Management (V1)```

We've included the version so that as the FAA amends it's document, that you will be able to distinguish between this persona, and any new one that you might create!

## b. Now enter a brief description. If you want to edit this part later on your computer desktop, just type ```Desc``` as a placeholder. That's what we will do here.

## c. Now enter a detailed Info Label. Info Labels are designed to suitably pad out the Description and can give warnings and Notes. If you want to edit this part later on your computer desktop, just type ```Info``` as a placeholder. That's what we will do here.

## d. Let's finalise our Data Set, adding to the FAA's minimum because it makes sense to us:

* **Flight Number** - so that the data backend can link the drone persona and the pilot persona, the later which will seperately be firehosing data into the Azure Event Hub, but which can be joined by the backend into a single dataset.
* **Drone Name** - as all users with the same persona installed will be able to see this, a drone name is a good marketing opportunity. On a sidenote, the first drone to use this system is called Hooty-Tooty. It's a DJI Mavic 2 Pro. 
* **Drone Id** - catering for our self assigned Identity Number, but being capable of storing a national or international Identity Number.
* **Drone Id County Code** - catering for national and international Drone Id Scenarios, if they ever materialise
* **Drone Latitude** - the present latitude of the drone
* **Drone Longitude** - the present longitude of the drone
* **Drone Altitude** - the altitude in meters, derived by GPS or any means that is not based upon Barometric Pressure
* **Drone Speed** - in m/s
* **Drone Heading** - to 0.1 degree accuracy, eg 275.1 degrees
* **Barometric Pressure** - in mBar (millibars) or Hectopascals (eg. 1013.23 mBar = 1013.25 hectopascals)
* **Timestamp** - the timestamp of the data set in ticks, which is the number of 100-nanosecond intervals that have elapsed since 12:00:00 midnight, January 1, 0001 (0:00:00 UTC on January 1, 0001, in the Gregorian calendar)

The first thing that you might notice is that these fields correspond to the existing ```Drone Aircraft``` Well-Known Proximity Profile™, in the Who™ Me app! 

*So why create another one?*

The simple matter is that that profile was created for broadcasting drone data to observers in the local vicinity, it wasn't designed for firehose data ingress into an Azure Database, and quite likely a drone would fly with both of these switched on. 

Also, the more astute developers will also realise that it is possible to capture the existing ```Drone Aircraft``` persona data and firehose that into the Azure Event Hub as well!

## e. Correlate the Data Set with the Persona Standard Input Fields

If you examine the ```Create Custom Persona``` Editor, you will see a section called ```Editable Keys```, which has an ```Add Key``` button. 

What we need to do here is to add a Key for each element of the Data Set, above, and tapping the ```Add Key``` button will reveal the following types of data fields that we can add to our ```Custom Proximity Persona```:

* Latitude,
* Longitude,
* Altitude,
* Speed,
* Heading,
* Standard Text Input,
* Clickable Web Addresses, opening the device browser,
* Clickable Phone Numbers, opening the device dialler,
* Country Code Picker,
* Date Picker,
* Time Picker,
* Tappable URL Macro
* Immediate URL Macro
* Relayable URL Macro

**Hint:** You will also notice a ```Full-Screen``` icon next to the ```Add Key``` button. Although you don't need to add the keys in Full-Screen Mode, it's easier. Press the Full-Screen button, if you wish, if you do so, you will see that it toggles to a ```Revert Screen``` icon!

Here, I'll describe the adding of the keys for each of the above Data Set members.

But be aware that when you have finished adding keys for all of the above Data Set members, there are two **Macro Keys** to add! 

```Macros Keys``` give Proximity Profiles additional functionality, and there are two additional ones we want to add. 

I'll describe those after adding all the Data Set keys!

* **Flight Number Key**. Tap ```Add Key``` and enter the name of the Key as _Flight Number_. Scroll down to the ```Standard Text Input``` button and tap it. You will see that a key named **Flight Number** has been added to the Key list, and it has a type displayed as ```Standard Text Input```, and a **Macro Key** value of 1. 

* **Drone Id Key**. Tap ```Add Key``` and enter the name of the Key as _Drone Id_. Scroll down to the ```Standard Text Input``` button and tap it. You will see that a key named **Drone Id** has been added to the Key list, and it has a type displayed as ```Standard Text Input```, and a **Macro Key** value of 2. 

* **Drone Id Country Code Key**. Tap ```Add Key``` and enter the name of the Key as _Drone Id Country Code_. Scroll down to the ```Country Code Picker``` button and tap it. You will see that a key named **Drone Id Country Code** has been added to the Key list, and it has a type displayed as ```Country Code Picker```, and a **Macro Key** value of 3.

* **Drone Latitude**. There is nothing to do here as all Proximity Profiles generate a Latitude. If you wanted to include Latitude in a Macro, it always has the Macro Key called M1.

* **Drone Longitude**. There is nothing to do here as all Proximity Profiles generate a Longitude. If you wanted to include Longitude in a Macro, it always has the Macro Key called M2.

* **Drone Altitude**. Tap ```Add Key``` and enter the name of the Key as _Altitude_. Scroll down to the ```System Altitude``` button and tap it. You will see that a key named **Altitude** has been added to the Key list, and it has a type displayed as ```System Altitude```, and a **Macro Key** value of 4.

* **Drone Speed**. Tap ```Add Key``` and enter the name of the Key as _Speed_. Scroll down to the ```System Speed``` button and tap it. You will see that a key named **Speed** has been added to the Key list, and it has a type displayed as ```System Speed```, and a **Macro Key** value of 5.

* **Drone Heading**. Tap ```Add Key``` and enter the name of the Key as _Heading_. Scroll down to the ```System Heading``` button and tap it. You will see that a key named **Heading** has been added to the Key list, and it has a type displayed as ```System Heading```, and a **Macro Key** value of 6.

* **Barometric Pressure**. Tap ```Add Key``` and enter the name of the Key as _Barometric Pressure_. Scroll down to the ```System Pressure``` button and tap it. You will see that a key named **Barometric Pressure** has been added to the Key list, and it has a type displayed as ```System Pressure```, and a **Macro Key** value of 7.

* **Time Stamp**. Tap ```Add Key``` and enter the name of the Key as _Time Stamp_. Scroll down to the ```System Timestamp``` button and tap it. You will see that a key named **Time Stamp** has been added to the Key list, and it has a type displayed as ```System Timestamp```, and a **Macro Key** value of 8.

We also need to add two different Macros, and I'll explain each one as follows:

* **Immediate Macro Async**. Tap ```Add Key``` and enter the name of the Key as _Immediate Macro Sync_. Scroll down to the ```Immediate URL Macro``` button and tap it. You will see that a key named **Immediate Macro Sync** has been added to the Key list. However, two things are different about this list item, when compared to the previous ones.

First of all, the list item does NOT have a Macro Key. That's because Macros cannot be included in other Macros!

Secondly, there is a red 'Edit' note that says "Please enter the encoded URL:", and it  gives an example.

To explain this, I have to explain what an **Immediate** macro is. ```Immediate``` macros run on the device that is ```transmitting``` the persona, not the one ```receiving``` it. By contrast, **Relayable** macros run on the device ```receiving``` the transmission, not the one ```transmitting``` it.

So, for examaple, if you 'long-pressed' the Key item that you have just created, you would be able to enter the following URL and then press ```Finish Editing```:

http://www.mycustomwebsite.com/?flightnumber=[1]&droneid=[2]&droneidcc=[3]&latitude=[M1]&longitude=[M2]&altitude=[4]&speed=[5]&heading=[6]&timestamp=[7]&barometer=[8]

This is the ```Immediate URL Macro``` url, and every time that this Proximity Persona is transmitted by a device, this URL is called on the web as a GET request, but with the real values replacing the Macro Keys. It does not store a response, it's purpose is to firehose information at a URL, it hopes for a response of 2oo OK but ignores everything that is not that.

So far, you know how to make a Custom Proximity Persona using an Immediate URL Macro, that if we created a URL, would send the information as described. 

However we want to use this Macro ```Synchronously``` in another app and NOT make the URL call in the Who™ Me app. 

For beginners, ```Synchronous``` just means 'at the same time'.

_So how do we stop the Macro making the URL Call in the Who™ Me app, and allow it to make it's own calls at the same time, in another Companion App?_

Quite simply, long-press the Immediate URL Macro list item that you have just created and type in the following pseudo URL: 

http://sync/

Then (but not until you have finished creating this persona), go into the settings and look for the heading **Broadcast Receivers** - you will see an item called ```Immediate Broadcast Receivers``` and a switch, which needs to be toggled to the ON position!

_Now, we will add our last ```Proximity Persona Key```, a ```Relayable URL Macro```:_

* **Relayable Macro Async**. Tap ```Add Key``` and enter the name of the Key as _Relayable Macro Sync_. Scroll down to the ```Relayable URL Macro``` button and tap it. You will see that a key named **Relayable Macro Sync** has been added to the Key list. As with the Immediate URL Macro, this item does not have a Macro Key, and it also needs to be edited. Edit this item with the URL http://sync/ as before.

Relayable URL Macros are the same as Immediate URL Macros in all but one aspect - where the Immediate URL Macro causes the URL to be called immediately when the proximity Persona is broadcast on the transmitting device, Relayable URL Macros cause the URL to be called on the device that is receiving the Proximity Profile broadcast.

Drone Traffic Management has a curious use case where there is a need for **both** Immediate and Relayable URL Macros to be included in the same Proximity Persona. 

Imagine that your drone has the Who Me app installed on it, as well as the Proximity Persona that we are creating, and the Companion App that we are creating. 

The Companion App for the drone processes the Immediate URL Macro and immediately sends the data set to the Event Hub. 

_But what happens if the drone suddenly loses it's cellular data channel?_

That use case is why the Relayable URL Macro is included, although it is not used on the ```Drone Aircraft Companion App``` on the _sending device_, the ```Drone Pilot Companion App``` receives the information on the Remote Pilot's _receiving device_, via the Remote Pilot's Who™ Me app making it available to the Drone Pilot Companion App.

How the Drone Pilot Companion app treats this data is up to how the Drone Pilot Companion App is coded, and keeping in mind that this Companion App is sending the Remote Pilot's Data Set into the Event Hub, the same Companion App is able to query the Event Hub to see if the Drone's data-set is arriving in the Event Hub. If it is, there is no need for the Drone Pilot Companion App to relay the drone's data set into the Event Hub, but when it detects that the drone has stopped sending it's information to the Event Hub, in the case of a cellular failure, then the Drone Pilot Companion App can start sending the drone's ```relayed``` information into the Event Hub for it.

Now, if you had previously tapped the ```Full-Screen``` icon to make the ```Add Keys``` screen go full-screen, tap it again so that it reverts to a normal screen.

Scroll down to the ```Original Persona Author``` section and fill out the author fields. If you had already created a default author in the ```Settings``` page, these fields would be auto-filled.

**Hint:** If you create numerous Custom Proximity Personas, it is a good idea to use the same Author Id; many of these Proximity Profiles will end up in the public domain and we have it on our to-do list to eventually gather these together in a Who™ Me Cloud website, indexed by the Author Id.

So! Now that you have taken care of the Author information, press ```Save```. You can ```Preview``` it first, if you like!

Once you have pressed save, and you return to the Home Screen, scroll across to both the ```Receiving``` and ```Sending``` tabs.

In the ```Custom Who™ Me Personas``` section of each page, you will see a new Custom Proximity Profile called ```FAA Compliant UAV Traffic Management (V1)```.

If you tap on it in the ```Receiving``` tab, you will see a definition of the information that you will receive, if you activate this persona in Discovery Mode.

And if you tap on it in the ```Sending``` tab, in addition to seeing a definition of the information that your device can automatically send, you will also see those editable fields that you created so that you can fill out the drone name, drone id, and drone id country-code, etc.

For the moment, just ignore the matter that you havent added the Persona's Description or Info Fields yet, we will deal with that in a moment.

Meanwhile, consider that if you fill out the editable fields in the sending section, then activate the Persona, then switch the app into Discovery Mode, then your device will start transmitting this profile as though it was a drone. But that's not what you want, you want your drone to be transmitting this profile in Discovery Mode. How do you enable that?

Without you realising it, many drones are built around the Snapdragon series of processors, and at the time of writing, the Snapdragon 855 leads this field. Many mobile phones also use the Snapdragon series, such as many Samsung Mobile phones. 

Of course, right now you can't wait for the new range of drones that we believe will come out that will support loading apps directly onto them from the Google Play Store, so we have created a 3D-Printable housing that we call a 'pig' that automatically snaps onto a Mavic 2 Pro drone and will hold any of a number of mobile phones. Just grab a cheap device that supports the Who™ Me app and install both app and phone on your drone. We created the pig so that other creators can modify the pig to snap-onto any drone, and we hope that you will see many of these quickly become available for you to print. Or adapt the files yourself!

We define a drone pig as a device that can be added to a drone that has the capacity to download apps from the Google Play Store.

We are also in the process of designing a bespoke drone-pig ourselves, based upon the Snapdragon 855 Hardware Developer's Kit at https://developer.qualcomm.com/hardware/snapdragon-855-hdk

There's a great video on YouTube about it here: https://www.youtube.com/watch?v=tqUlXGEugk0

We believe that Who™ Me will drive this market forwards, and in time you will see two things:

* **Snapdragon 855 based Drone-Pigs** being made available to attach to a range of existing drones, such as those used in Search and Rescue, which will be capable of downloading apps from the Google Play Store.
* **Drones with Built-In Drone-Pigs** that are the built around upon the ilk of the Snapdragon 855 and are similarly capable of downloading apps from the Google Play Store.

Meanwhile, you will have to do with snapping an Android mobile handset into a drone-pig housing yourselves! Or if you are really geeky, just securely velcro an existing handset onto your drone, but remember, you are responsible for it being secure!

We use an old Samsung S5 that we purchased some years ago, that found it's way into our bottom drawer!

So, having sorted out your drone-pig, download a copy of Who™ Me onto it. You now need to share the custom persona that you have created, and install it in the drone-pig device!

To share the custom profile, go into a ```Receiving``` page and long-press the Custom Proximity Profle called ```FAA Compliant UAV Traffic Management (V1)```. You will see a Share button appear, tap that!

Your device will show a file called ```FAA Compliant UAV Traffic Management (V1).txt```, and the first thing that you will need to do is change the file extension to ```.whome```.

Share that to a location where you can retrieve it!

Normally, you would then just share this to your drone-pig device, as by clicking it in the drone-pig device, you will get the opportunity to load it into the Who™ Me app on that device.

But first, remember, we still need to fill out the ```Description``` and ```Info Label``` fields.

So, open the file on your computer desktop that you have generated, which is called ```FAA Compliant UAV Traffic Management (V1).whome```

You will see that this is just a cleverly laid out text file. Look for both of the ```Description``` and ```Info Label``` fields, and edit into them a Description and Info Label. Be sure to not use double quotation marks (```"```) in those fields as the double quotation mark is a reserved character.

We have done this for you in the following example:

N.B. The only differences between your custom profile, and ours, will be the author details, the Profile Id in the ```Guid``` field, and the repetition of the Guid in the ```FullDomainName``` field. These differences wont matter, because so long as the same custom persona is shared to both the Remote Pilot's device, and the drone-pig, then they will talk to each other!

```
{
  "ProfileAPIVersion": "1",
  "Guid": "86f9519b-fbde-4f86-828e-75f37df17665",
  "ProfileCreatedDate": "2019-12-31T00:00:00",
  "ProfileExpiryDate": "0001-01-01T00:00:00",
  "ProfileDocumentationWebAddress": null,
  "Name": "FAA Compliant UAV Traffic Management (V1)",
  "Description": "desc",
  "InfoLabel": "info",
  "FullDomainName": "86f9519b-fbde-4f86-828e-75f37df17665._whome._tcp._local",
  "ServiceInfoDictionary": {
    "1": "<Mandatory>",
    "2": "<Mandatory>",
    "A": "<Optional>",
    "B": "<Optional>",
    "C": "<Optional>",
    "D": "<Optional>",
    "E": "<Optional>",
    "F": "<Optional>",
    "G": "<Optional>",
    "H": "<Optional>",
    "I": "http://sync/",
    "J": "http://sync/"
  },
  "KeyNameMap": {
    "1": "Latitude",
    "2": "Longitude",
    "A": "Flight Number",
    "B": "Drone Id",
    "C": "Drone Id Country Code",
    "D": "Drone Altitude",
    "E": "Drone Speed",
    "F": "Drone Heading",
    "G": "Barometric Pressure",
    "H": "Time Stamp",
    "I": "Immediate Macro Sync",
    "J": "Relayable Macro Sync"
  },
  "KeyTypeMap": {
    "1": "System:Latitude",
    "2": "System:Longitude",
    "A": "String:TextInput",
    "B": "String:TextInput",
    "C": "String:ISO3166CC",
    "D": "System:Altitude",
    "E": "System:Speed",
    "F": "System:Heading",
    "G": "System:Pressure",
    "H": "System:Timestamp",
    "I": "Macro:URLImmediate",
    "J": "Macro:URLRelayable"
  },
  "KeyToMacroIdMap": {
    "A": "1",
    "B": "2",
    "C": "3",
    "D": "4",
    "E": "5",
    "F": "6",
    "G": "7",
    "H": "8"
  },
  "MacroIdToKeyMap": {
    "1": "A",
    "2": "B",
    "3": "C",
    "4": "D",
    "5": "E",
    "6": "F",
    "7": "G",
    "8": "H"
  },
  "EditableKeys": [
    "A",
    "B",
    "C",
    "D",
    "E",
    "F",
    "G",
    "H",
    "I",
    "J"
  ],
  "AuthorGuid": "",
  "AuthorName": "",
  "AuthorEmail": "",
  "OrganisationName": "",
  "WebAddress": ""
}
```

Now that you have edited the ```Description``` and ```Info Label``` fields, save your ```FAA Compliant UAV Traffic Management (V1).whome``` file.

Before installing the Custom Proximity Persona on your drone pig, you need to go back into the device where you created the Persona, and delete it. This is because it doesn't contain the new edit of the ```Description``` or ```Info Label``` fields. If you had the patience to write out a complete description and info label on your mobile handset when creating the persona, you wont need to do this step. Or perhaps you created the profile on an Android tablet, where this process would have been easy.

To delete the persona, go to any Receiving Screen and long-press the Custom Persona called ```FAA Compliant UAV Traffic Management (V1)```. You will see a ```Delete``` button appear in the ```Context Menu``` - tap it to delete the persona!

You can also go into the ```Delete``` page and do the same, which is available in the ```Menu```.

So now you should have two devices that both need the custom ```FAA Compliant UAV Traffic Management (V1)``` proximity profile installed on them.

Share the file ```FAA Compliant UAV Traffic Management (V1).whome``` to both devices with the Who™ Me app already installed, and try to open the file on both devices.

You will be offered a screen that allows you to open the ```FAA Compliant UAV Traffic Management (V1).whome``` file in the ```Who™ Me app```.

Select the ```Who™ Me app``` and the custom ```FAA Compliant UAV Traffic Management (V1)``` proximity profile will appear on any page that has either a ```Receiving``` or ```Sending``` screen.

If you activate the profile in ```Sending``` mode in your drone pig, and also in ```Receiving``` mode in your Remote Pilot device - and switch both apps into ```Discovery Mode```, you can happily fly your drone around right now, and the drone's position and details will be reported to your Remote Pilot handset. But be sure to tap on the ```Sending``` persona first and fill out the fields ```Drone Name```, etcetera, if you don't, these fields wont be transmitted, but the rest that are known by the device, such as latitude, longitude, pressure, etcetera, will. 

* **Side Note:** Barometric Pressure was introduced to the Android operating system back in Android 4.4, and at the time of writing, Android is up to version 10. You will have to ensure that the hardware device in your drone-pig is Barometric Pressure capable, we suspect that most devices are and we plan on releasing a free utility app to the Google Play Store that you will be able to install on your devices to check what sensors that they have that are built-in. For now, you can either cross your fingers and hope, checking to see if the value is transmitted - or you can do a little research online about your specific device, to see if it is capable. We'd be interested to learn which devices are NOT Barometric Pressure capable, so if you come across one, you are welcome to send an email to ```developers@whome.cloud``` with the subject heading ```Device without Barometric Pressure``` and tell us the model of the handset. We will create a list at the bottom of this post so that people who want to buy second hand phones to use as drone-pigs, will know which models to avoid.

So fly your drone around a bit and enjoy being able to see where your drone is, in the Who™ Me app in your Remote Pilot handset ... and if you distribute the same persona to anyone else, they will be able to see it in their Who™ Me app as well!

However in addition to this functionalty, we alkso want to make a ```Companion App``` that can be installed on both the drone-pig, and Remote Pilot's handset, which, as the drone flies around, will ingress this information into a Microsoft Azure Event Hub.

The following sections explain how to do this! 

_And it's quite easy to do!_

# 2. Create your Free Microsoft Azure Account

You can create a Free Azure subscription here: https://azure.microsoft.com/en-gb/free/

You will need this later, to create your Event Hub that the Compnion App sends your data.

# 3. Download your Free Visual Studio 2019 Community Edition, or Trial Paid Edition

Visual Studio is the Integrated Development Environment (IDE) that you will use to create your Companion App. 

It installs on both MacOS and Microsoft Windows, and if you are a beginner, don't be afraid to jump in feet-first, even we veterans started off in 'monkey-see-monkey-do' mode, you just need to view this tutorial as a recipe in a cook-book!

You can download Visual Studio here: https://visualstudio.microsoft.com/downloads/

# 4. Create a Who™ Me Companion App

## a. Choose Your Path:
You have three choices here:

### Option 1

Download the code for our Who™ Me Broadcast Viewer utility app that we have already published in the Google Play Store. 

This just needs to have code added to it that causes the app to send the data to the Event Hub that you will create. 

You will be able to add the code that you need, by following this tutorial. 

You will also need to change the branding graphics from our Who™ Me trademarks to your own.

### Option 2

Download the completed demonstration Companion App, and just add the Event Hub connection credentials. 

You will also need to change the branding graphics from our Who™ Me trademarks to your own.

### Option 3

Use Visual Studio to create your own new solution from scratch, using the tutorial as a guide to what you need to add to create a Minimum Viable Product (MVP).

**Remarks**

We will follow **Option 1** in this tutorial, and at the end of it, the code will be the same as already exists in **Option 2**.

**Option 3** is for more advanced beginners, and if you need a pointer, start **Visual Studio**, then choose ```File / New Solution``` then select ```App``` under ```multi-platform```, and either select ```Tabbed Forms App``` (which is what we used to build the first option, above, and provides a tabbed framework), or select  ```Master-Detail Forms App```, if you want a menu-based page navigation system. 

There are plenty of online videos to guide beginners forwards! 

The keywords to search for are ```Xamarin Forms Tutorial```, to learn about how to build cross-platform apps for Android and iOS, and ```C# Tutorial```, to learn about how to program in the language that these templates create, which is ```C#``` and is pronounced C-Sharp ('see-sharp').

**Alternatives**

Although this demonstration ```Companion App``` is coded in the programming language called ```C#```, a Companion App can also be built using other languages, such as ```C++```, ```Java```, and ```Kotlin```.

We hope that other members of the ```Who™ Me Community``` will create tutorials to illustrate how to create Companion Apps using those languages, however you will be pleased to know that it is also on our roadmap to eventually create one in ```Java```.

## b. Download the Code:

### Option 1

* If you have chosen the first option, go to the main page for this repository at https://github.com/HeyYouWhoMe/BroadcastViewer
* You will see a horizontal green line, make sure that the button on the left says ```Branch: master```, then tap the Green ```Clone or Download``` button on the right.
* This will show you a ```Download Zip``` link, click that to download.
* Copy the downloaded zip file to a directory that you have created for it somewhere that is convenient.
* Unzip the zip file into that directory, then delete the zip file.
* Click the directory that the zip unpacked into, then open the file called ```WhoMe.BroadcastReceiverViewer.sln```, that will open Visual Studio and load the solution code into the IDE.

### Option 2

* If you have chosen the second option, go to the main page for this repository at https://github.com/HeyYouWhoMe/BroadcastViewer
* You will see a horizontal green line, and on the left there will be a button that says ```Branch: master```, click that button and change the selected branch to ```eventhubdemo``` so that the button reads ```Branch: eventhubdemo```
* Tap the Green ```Clone or Download``` button on the right.
* This will show you a ```Download Zip``` link, click that to download.
* Copy the downloaded zip file to a directory that you have created for it somewhere that is convenient.
* Unzip the zip file into that directory, then delete the zip file.
* Click the directory that the zip unpacked into, then open the file called ```WhoMe.BroadcastReceiverViewer.sln```, that will open Visual Studio and load the solution code into the IDE.

### Advanced Users

Clone the respective branches from the command-line, as follows:

#### Option 1

```
git clone git@github.com:HeyYouWhoMe/BroadcastViewer.git
```

#### Option 2

```
git clone git@github.com:HeyYouWhoMe/BroadcastViewer.git
git checkout eventhubdemo
```

## C. Code Your App

### Preliminary Description of the Codebase

The Who Me Broadcast Viewer app that we are using as a basis to extend to further channel information to an Event Hub, has been created in C# using the Xamarin Forms framework: as such it consists of two main projects, whose names are as follows:

* WhoMeBroadcastReceiverViewer, and
* WhoMeBroadcastReceiverViewer.Android.

The first project, WhoMeBroadcastReceiverViewer, is a generic cross-platform Xamarin Forms project, and this project contains the majority of things that are needed for the app to be cross-platform. Although this solution doesn't target other cross platform environments, such as iOS (iPhone, iPad), Windows (UWP, WPF), and Raspberry Pi (via UWP), this project is capable of doing so. 

We will, however, only use this project to target Android.

WhoMeBroadcastReceiverViewer contains:

* Views - the pages that the user sees, for example, the About page
* ViewModels - the mechanics that cause the views to display their information, for example, the About page has a ViewModel associated with it called the About ViewModel
* Models - The essential classes that allow the business rules to be implemented, for example, when a Who Me Persona is received as a stream of text from the device, that information needs to be put in the 'SharedWhoMePersona' class so that elements of it, called properties, can be referred to in code.
* Services - The classes that provide a specific service and internally encapsulate the work they do, for example, the MyAzureEventHubService can be assumed to send information to an Azure Event Hub

The second project, WhoMeBroadcastReceiverViewer.Android, is a platform based app that is created to suit the specific operating system that it serves; in this case it is configured to install on Android devices, and the previous cross-platform Xamarin Forms project, sits on top of this project.

WhoMeBroadcastReceiverViewer.Android contains:

* SplashActivity - the Android way of creating the 'splash' page that you see at startup. This cannot be a Xamarin Forms View because when the application is starting, the Xamarin Forms project is yet to start.
* MainActivity - an Android app's main startup configuration page, which launches the Xamarin Forms App class that controls the Xamarin Forms page navigation system.
* BroadcastReceivers - these exist as three class files, one which receives Immediate persona broadcasts, another that receives Relayable persona broadcasts, and another that recives Regular persona broadcasts, that is, those that are neither Immediate nor Relayable.
* Resources - which include the images that you see at startup, and on the About page, as well as various configuration files that define Android things, such as the Android tab bar colour.
* Various minor files that are included as part of the system but which developers rarely need to look at or touch.

In addition to all of this, both projects have Reference and Dependency objects, including packages, that contain code that other developers have written that make things easier to do. One of the packages, for example, is called Json.Net, and it is used to 'deserialise' (convert) the text that is received from the Who Me app, into the model that it needs to become to be useful in this app, the SharedWhoMeProfile class.

### How the app presently works

When the app first starts, before it does anything, it looks through the Activity files that it has, and looks for a property ```MainLauncher = true```.

It finds this in the SplashActivity, which you can see as follows:


```
    [Activity(Label = "Broadcast Viewer",
        Icon = "@mipmap/icon",
        Theme = "@style/splashscreen", 
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
```

You will notice the line ```Theme = "@style/splashscreen"```, it points to the file ```Resources/values/styles.xml```, and this file has the following:

```
      <style name="splashscreen" parent="Theme.AppCompat.Light.NoActionBar">
        <item name="android:windowBackground">@drawable/splash</item>
        <item name="android:windowNoTitle">true</item>
        <item name="android:windowIsTranslucent">false</item>
        <item name="android:windowIsFloating">false</item>
        <item name="android:backgroundDimEnabled">true</item>
      </style>
```

In turn, the following line

```
<item name="android:windowBackground">@drawable/splash</item>
```

points to the file ```Resources/drawable/splash.xml```, and this file is as follows:

```
<?xml version="1.0" encoding="utf-8"?>
<layer-list xmlns:android="http://schemas.android.com/apk/res/android">
    <item>
        <color android:color="@color/launcher_background"/>
    </item>
    <item>
        <bitmap
            android:src="@drawable/flash_icon_overlay_splash_screen"
            android:tileMode="disabled"
            android:gravity="center"/>
    </item>
</layer-list>
```

Finally! We are at a place that you will recognise two things:

* When the app lunches, you see the Who Me logo, and it's file path is ```Resources/drawable/flash_icon_overlay_splash_screen.png```,
* When the app launches the background colour of the screen is black, and the line ```<color android:color="@color/launcher_background"/>``` points to the file REsources/values/colors.xml, and the value of the ```launcher_background``` is defined in that file as black.

You will notice that after the Splash Screen, the apps main pages are displayed in a tab bar, and that is because in the first ```SplashActivity``` class, above, the line ```StartActivity(typeof(MainActivity));``` tells the app to launch the MainActivity.

This file contains the rest of the start-up sequence in the following ```OnCreate``` method:

```
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            if (!SimpleIoc.Default.IsRegistered<ImmediateViewModel>())
            {
                SimpleIoc.Default.Register<ImmediateViewModel>(() => _immediateViewModel);
            }

            if (!SimpleIoc.Default.IsRegistered<RelayableViewModel>())
            {
                SimpleIoc.Default.Register<RelayableViewModel>(() => _relayableViewModel);
            }

            if (!SimpleIoc.Default.IsRegistered<RegularViewModel>())
            {
                SimpleIoc.Default.Register<RegularViewModel>(() => _regularViewModel);
            }

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
```

The first three lines are typical of most Android apps, the last three are merely how the Cross Platform Xamarin Forms project is launched, however between the top three lines, and the bottom three lines, are the essential declarations that we have made, about code that we have created in other files.

* ImmediateViewModel - this 'View' model controls what is displayed in the ImmediatePage
* RelayableViewModel - this 'View' model controls what is displayed in the RelayablePage
* RegularViewModel - this 'View' model controls what is displayed in the RegularPage

Here, I should explain the purposes of the pages:

* ImmediatePage - to display raw transmission text that is received from Personas behaving as an Immediate Macro, in the current context 
* RelayablePage - to display raw transmission text that is received from Personas behaving as a Relayable Macro, in the current context 
* RegularPage - to display raw transmission text that is received from Personas behaving neither as Immediate nor Relayable Macros, in the current context

To give you an overview of how pages work, I'll discuss the ImmediatePage.

Pages are officially a class called ```ContentPage```, and these have two linked files:

* A ```xaml``` file - here it's called ```ImmediatePage.xaml```
* A ```C#``` file - here it is called ```ImmediatePage.xaml.cs```

You will often here the ```.xaml.cs``` file called 'code-behind', because it is the code behind the ```xaml``` that it relates to.

Here is the ```ImmediatePage.xaml``` file in all it's glory:

```
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="WhoMeBroadcastReceiverViewer.Views.ImmediatePage">
    <ContentPage.Content>
        <Grid BackgroundColor="Blue">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="Auto"/>
            </Grid.RowDefinitions>
            <Label Grid.Row="0" Text="Data Received" FontSize="Title" TextColor="Yellow" FontAttributes="Bold" HorizontalOptions="Center" VerticalOptions="Center" Margin="10,10,10,0" />
            <Label Grid.Row="1" Text="{Binding Timestamp}" FontSize="Body" TextColor="Yellow" FontAttributes="Bold" HorizontalOptions="Center" VerticalOptions="Center" Margin="10,0,10,0" />
            <ScrollView Grid.Row="2">
                <Label Text="{Binding MacroInfo}" TextColor="White" LineBreakMode="WordWrap" VerticalTextAlignment="Start" VerticalOptions="Start" Margin="10"/>
            </ScrollView>
            
            <Grid Grid.Row="3" BackgroundColor="Black">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <Button Grid.Column="0" Command="{Binding ClearCommand}" Text="{Binding ClearButtonText}" BackgroundColor="#FF4500"/>
                <Button Grid.Column="1" Command="{Binding ToggleCommand}" Text="{Binding ToggleButtonText}" BackgroundColor="#FF4500"/>
            </Grid>

        </Grid>
    </ContentPage.Content>
</ContentPage>
```

Most of this file is just all about how to layout various significant components, and in this case the significant components are:

* The 'label' that displays the raw persona text that is received:

```
<Label Text="{Binding MacroInfo}" TextColor="White" LineBreakMode="WordWrap" VerticalTextAlignment="Start" VerticalOptions="Start" Margin="10"/>
```

You can see that the label gets it's information from the ```MacroInfo``` property in the ViewModel. Here is that property in the ImmediateViewModel:

```
string _macroInfo = string.Empty;
public string MacroInfo
{
    get { return _macroInfo; }
    set { SetProperty(ref _macroInfo, value); }
}
```

* The 'clear button' that the user taps to clear the screen:

```
<Button Grid.Column="0" Command="{Binding ClearCommand}" Text="{Binding ClearButtonText}" BackgroundColor="#FF4500"/>
```

You can see that tapping the 'clear button' invokes the ClearCommand in the ViewModel. Here is that property in the ImmediateViewModel:

```
public ICommand ClearCommand { get; set; }

...

ClearCommand = new RelayCommand(() =>
{
    MacroInfo = string.Empty;
    Timestamp = string.Empty;
});

```

_Quite clearly, the invoking of the ClearCommand clears both the MacroInfo, as well as the Timestamp. It is because both of the respective Label Text properties are bound to these properties in the ViewModel, that when the properties change, the text that they display changes. I haven't illustrated the Timestamp property or the Timestamp label, but they are just the same as the MacroInfo property and it's label, just the property names are changed._

* The 'toggle button' that toggles between paused and not paused. This is designed so that the user can stop the ViewModel adding the next Persona update before he has finished reading this one.

```
<Button Grid.Column="1" Command="{Binding ToggleCommand}" Text="{Binding ToggleButtonText}" BackgroundColor="#FF4500"/>
```

You can see that tapping the 'toggle button' invokes the ToggleCommand in the ViewModel. Here is that property in the ImmediateViewModel:

```
public ICommand ClearCommand { get; set; }

...


ToggleCommand = new RelayCommand(() =>
{
    _isDisplaying = !_isDisplaying;

    if(_isDisplaying)
    {
        ToggleButtonText = "Pause";
    }
    else
    {
        ToggleButtonText = "Listen";
    }
});
```

Quite clearly there is more going on that meets the eye here! How does the ToggleCommand prevent the text from updating? 

_The answer is in the ```_isDisplaying``` property, which is either ```true``` or ```false```_

In a short while I will introduce you to the Broadcast Receivers, which update these ViewModels, however you can see that when they are updated, how they work in the ViewModels:

```
public void UpdateMacroInfo(string info)
{
    if (_isDisplaying)
    {
        MacroInfo = info;
        Timestamp = "at " + DateTime.Now.ToLongTimeString();
    }
}
```

Bingo! There's the ```_isDisplaying``` variable! 

When the ToggleCommand has set it to ```true```, it lets the MacroInfo and Timestamp properties to be set. 

and when the ToggleCommand has set it to ```false```, it blocks the MacroInfo and Timestamp properties from being set.

_But how does the ImmediatePage know which ViewModel to use?_

Let's have a look at the code-behind for the ```ImmediatePage.xaml.cs```:

```
using System.Diagnostics;
using GalaSoft.MvvmLight.Ioc;
using WhoMeBroadcastReceiverViewer.ViewModels;
using Xamarin.Forms;

namespace WhoMeBroadcastReceiverViewer.Views
{
    public partial class ImmediatePage : ContentPage
    {
        public ImmediatePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.BindingContext = SimpleIoc.Default.GetInstance<ImmediateViewModel>();

            Debug.WriteLine("ImmediateViewModel bound");
        }
    }
}
```

Well, there's not much code there, but the pertinent line is:

```
this.BindingContext = SimpleIoc.Default.GetInstance<ImmediateViewModel>();
```

This line, for example, causes the Text property of the Label above, to be bound to the MacroInfo property in the ImmediateViewModel.

Similarly, in ```RelayablePage.xaml.cs```, there is a line as follows:

```
this.BindingContext = SimpleIoc.Default.GetInstance<RelayableViewModel>();
```

And in ```RegularPage.xaml.cs```, there is a line as follows:

```
this.BindingContext = SimpleIoc.Default.GetInstance<RegularViewModel>();
```

Before we get onto the Broadcast Receivers, let's examine one of these lines and wonder what the ```SimpleIoC``` object is all about!

Do you remember when the MainActivity called it's ```OnCreate``` method? There were a few lines that went like this:

```
if (!SimpleIoc.Default.IsRegistered<ImmediateViewModel>())
{
    SimpleIoc.Default.Register<ImmediateViewModel>(() => _immediateViewModel);
}

if (!SimpleIoc.Default.IsRegistered<RelayableViewModel>())
{
    SimpleIoc.Default.Register<RelayableViewModel>(() => _relayableViewModel);
}

if (!SimpleIoc.Default.IsRegistered<RegularViewModel>())
{
    SimpleIoc.Default.Register<RegularViewModel>(() => _regularViewModel);
}
```

Well, that is where we originally registered each ViewModel!

SimpleIoC is a special 'inversion of Control' service that, as a readily available Singleton object, allows us to register classes and then retrieve them from anywhere in the app.

You will notice that we registered an instance of the ImmediateViewModel in the MainActivity OnCreate method:

```
if (!SimpleIoc.Default.IsRegistered<ImmediateViewModel>())
{
    SimpleIoc.Default.Register<ImmediateViewModel>(() => _immediateViewModel);
}
```

and that we retrieved it in the ImmediatePage's code-behind:

```
this.BindingContext = SimpleIoc.Default.GetInstance<ImmediateViewModel>();
```

But why did we not just go ```this.BindingContext = new ImmediateViewModel();```, instead? 

You'll notice that the AboutViewModel was not registered in the application's startup process! 

And indeed, here is the AboutPage.xal.cs code behind page:

```
using WhoMeBroadcastReceiverViewer.ViewModels;
using Xamarin.Forms;

namespace WhoMeBroadcastReceiverViewer.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            this.BindingContext = new AboutViewModel();
        }
    }
}
```

The answer to this brings us merrily to the three BroadcastReceivers that shall be the focus of much the rest of this tutorial - we also need to refer to the ImmediateViewModel in the BroadcastReceivers so that we can use the ViewModel's ```UpdateMacroInfo(string info)``` method! 

Why is it to understand how to use SimpleIoC to register an object, and then later retrieve it? Ah yes, I remember, we are going to create a service to send drone data to an Azure Event Hub, and we will need to know how to register that with SimpleIoC!

But first, the existing BroadcastReceivers!

As stated previously, the app has three BroadcastReceivers, as follows:

* ImmediateBroadcastReceiver
* RelayableBroadcastReceiver
* RegularBroadcastReceiver

These are classes that we wrote, and if you are going to write your own bespoke Companion App for Who Me, you are going to have to be able to create them.

So, first of all, let's look at the ImmediateBroadcastReceiver first, and then we will discuss the significance of BroadcastReceivers in general.

```
    public class ImmediatePersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;
        private IMyAzureEventHubService _eventHub;

        public ImmediatePersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
            _eventHub = SimpleIoc.Default.GetInstance<IMyAzureEventHubService>();
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC");

            _updater.UpdateMacroInfo(receivedText);

            // If you want to send this information over a network, create a service and pass the info to it here!
        }
    }
```

We will eventually create some code to send the ```receivedText``` to the Event Hub we are going to create, replacing the following line with it:

```
    // If you want to send this infoamtion over a network, create a service and pass the info to it here!
```

Although we have created this class from scratch, the significance of it is in the first line, the matter that our custom ```ImmediatePersonaBroadcastReceiver``` extends the ```BroadcastReceiver``` class.

The ```BroadcastReceiver``` class is an Android Operating System class that gives us the following method:

```
public override void OnReceive(Context context, Intent intent)
{
    ...
}
```

And it is inside this method that we can receive messages that are broadcast by the operating system. That's why it is called a ```BroadcastReceiver```!

Now, as BroadcastReceivers exist in the context of receiving messages from the device's operating system, we could create a BroadcastReceiver to listen for an alarm that you have set in the clock app, for example ... or in this case, to receive a message from the operating system that the Who Me app had passed to it!

For an application to receive information like this from the operating system, another application has to send it. 

And for the other application to be able to send such messages, the other app has to register the broadcasts that it wants to send, with the Android operating system.

The Who Me app has registered three types of messages that it wants to broadcast, and they are as follows:

```
cloud.whome.apps.whome.BROADCAST_IMMEDIATE_PERSONA"
cloud.whome.apps.whome.BROADCAST_RELAYABLE_PERSONA"
cloud.whome.apps.whome.BROADCAST_REGULAR_PERSONA"
```

As you can see, we have designed our own registration strings that are based upon the Who Me domain name, but backwards - that way, there won't be a clash with any other app registering the same string to send.

_But any app can register to receive messages using these message types!_

You will also notice that the string in the broadcast receiver above (cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC) does not match any of the three strings that the Who Me app registered with the operating system!

This is because in the sending app, after the sending registering intent had declared the string to the operating system, it declared a child string to the same intent, and the operating systemn does not need to know about the child string.

In short, the three parent-child relationships are as follows:

```
For the Immediate URL Macro:
Parent - cloud.whome.apps.whome.BROADCAST_IMMEDIATE_PERSONA
Child - cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC

For the Relayable URL Macro:
Parent - cloud.whome.apps.whome.BROADCAST_RELAYABLE_PERSONA
Child - cloud.whome.apps.whome.SERIALISED_RELAYABLE_INFODIC

For Regular Non-Macro contexts:
Parent - cloud.whome.apps.whome.BROADCAST_REGULAR_PERSONA
Child - cloud.whome.apps.whome.SERIALISED_REGULAR_INFODIC
```

So this shows you a cool pattern about how to create Companion Apps:

* 'Register To Receive' a parent intent that the other app has registered to send using the parent string
* Use the child string as a key in the intent that is received to extract the relevant information from it

If you look at the code above, you can see a child string being used as a key to extract the received message:

```
string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC");
```

However the parent 'registration' string was registered elsewhere.

Before going on to look at how and where BroadcastReceivers are registered, so that they can receive content, I'll just add the two additional receivers here:

```
    public class RegularPersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;

        public RegularPersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_REGULAR_INFODIC");

            _updater.UpdateMacroInfo(receivedText);

            // If you want to send this information over a network, create a service and pass the info to it here!
        }
    }
```

and 

```
    public class RelayablePersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;

        public RelayablePersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_RELAYABLE_INFODIC");

            _updater.UpdateMacroInfo(receivedText);

            // If you want to send this information over a network, create a service and pass the info to it here!
        }
    }
```

Before moving on, you will notice in the constructors of all three of these BroadcastReceivers the following property:

```
IUpdateMacroInfo updater
```

you will notice that it is assigned to the following variable in the constructor:

```
_updater = updater;
```

and you will notice that when the text is received, it is passed to the same object:

```
_updater.UpdateMacroInfo(receivedText);
```

 is an interface that we created, which is as follows:

 ```
public interface IUpdateMacroInfo
{
    void UpdateMacroInfo(string info);
}
 ```

 This is because all of the ViewModels except for the AboutViewModel inplement this interface:

 ```
    public class ImmediateViewModel : BaseViewModel, IUpdateMacroInfo
    {
        ...

        public void UpdateMacroInfo(string info)
        {
            if (_isDisplaying)
            {
                MacroInfo = info;
                Timestamp = "at " + DateTime.Now.ToLongTimeString();
            }
        }
    }        
 ```

  ```
    public class RelayableViewModel : BaseViewModel, IUpdateMacroInfo
    {
        ...
        
        public void UpdateMacroInfo(string info)
        {
            if (_isDisplaying)
            {
                MacroInfo = info;
                Timestamp = "at " + DateTime.Now.ToLongTimeString();
            }
        }
    }        
 ```

  ```
    public class RegularViewModel : BaseViewModel, IUpdateMacroInfo
    {
        ...
        
        public void UpdateMacroInfo(string info)
        {
            if (_isDisplaying)
            {
                MacroInfo = info;
                Timestamp = "at " + DateTime.Now.ToLongTimeString();
            }
        }
    }        
 ```

 So this illustrates how, when each message is received in a BroadcastReceiver, how it is passed to the appropriate ViewModel:

 ```
_updater.UpdateMacroInfo(receivedText);
 ```

 So, let's go back to the MainActivity which booted up the Xamarin Forms project!

 ```
 [Activity(Label = "Broadcast Viewer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private ImmediatePersonaBroadcastReceiver _immediatePersonaBroadcastReceiver;
        private RelayablePersonaBroadcastReceiver _relayablePersonaBroadcastReceiver;
        private RegularPersonaBroadcastReceiver _regularPersonaBroadcastReceiver;

        private ImmediateViewModel _immediateViewModel;
        private RelayableViewModel _relayableViewModel;
        private RegularViewModel _regularViewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ... 
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            ...
        }
        protected override void OnStart()
        {
            base.OnStart();

            _immediateViewModel = new ImmediateViewModel();
            _immediatePersonaBroadcastReceiver = new ImmediatePersonaBroadcastReceiver(this, (IUpdateMacroInfo)_immediateViewModel);

            IntentFilter immediateFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_IMMEDIATE_PERSONA");

            RegisterReceiver(_immediatePersonaBroadcastReceiver, immediateFilter);

            _relayableViewModel = new RelayableViewModel();
            _relayablePersonaBroadcastReceiver = new RelayablePersonaBroadcastReceiver(this, (IUpdateMacroInfo)_relayableViewModel);

            IntentFilter relayableFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_RELAYABLE_PERSONA");

            RegisterReceiver(_relayablePersonaBroadcastReceiver, relayableFilter);

            _regularViewModel = new RegularViewModel();
            _regularPersonaBroadcastReceiver = new RegularPersonaBroadcastReceiver(this, (IUpdateMacroInfo)_regularViewModel);

            IntentFilter regularFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_REGULAR_PERSONA");

            RegisterReceiver(_regularPersonaBroadcastReceiver, regularFilter);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterReceiver(_immediatePersonaBroadcastReceiver);
            UnregisterReceiver(_relayablePersonaBroadcastReceiver);
            UnregisterReceiver(_regularPersonaBroadcastReceiver);
        }
    }
 ```

 I'll go through this piece by piece, as it is very simple!

 First, each of the three BroadcastReceivers that you have already seen, are registered as private variable:

 ```
        private ImmediatePersonaBroadcastReceiver _immediatePersonaBroadcastReceiver;
        private RelayablePersonaBroadcastReceiver _relayablePersonaBroadcastReceiver;
        private RegularPersonaBroadcastReceiver _regularPersonaBroadcastReceiver;
 ```

 Then, each of the three ViewModels that are registered with SimpleIoC so that they can be used anywhere, are registered as private variables.

 ```
        private ImmediateViewModel _immediateViewModel;
        private RelayableViewModel _relayableViewModel;
        private RegularViewModel _regularViewModel;
 ```

 Although the registration of the ViewModels occurs in the OnCreate method (not shown here but you have seen it before), significantly, the OnStart() method fires before the OnCreate(...) method!

 Because we need the ViewModels here, so that we can pass them into the BroadcastReceivers as we create them, we also create the ViewModels here, which are then registered with SimpleIoC when OnCreate(...) is later called.

 vis-a-vis:

 ```
            ...

            _immediateViewModel = new ImmediateViewModel();

            ...

            _relayableViewModel = new RelayableViewModel();

            ...

            _regularViewModel = new RegularViewModel();

            ...
 ```

 Once each of the ViewModels is registererd, we then create each of the BroadcastReceivers:

 ```
            _immediateViewModel = new ImmediateViewModel();
            _immediatePersonaBroadcastReceiver = new ImmediatePersonaBroadcastReceiver(this, (IUpdateMacroInfo)_immediateViewModel);
 ```

 Notice how we are passing the ViewModel into the BroadcastReceiver - it is because each ViewModel implements the IUpdateMacroInfo interface, that we can tell each BroadcastReceiver that it is receiving an IUpdateMacroInfo, it has no idea that it is getting a ViewModel, it just knows that it can call the IUpdateMacroInfo ```UpdateMacroInfo``` method that is declared in that interface!

 Next, the following two lines are crucial:

 ```
            _immediateViewModel = new ImmediateViewModel();
            _immediatePersonaBroadcastReceiver = new ImmediatePersonaBroadcastReceiver(this, (IUpdateMacroInfo)_immediateViewModel);

            IntentFilter immediateFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_IMMEDIATE_PERSONA");

            RegisterReceiver(_immediatePersonaBroadcastReceiver, immediateFilter);
 ```

 The first of these next two lines assigns the registration string ```cloud.whome.apps.whome.BROADCAST_IMMEDIATE_PERSONA``` to an intent.

 And the second of these two lines registers BOTH the Broadcast Receiver, and the intent.

 Basically, the RegisterReceiver(...) line says "Send messages about cloud.whome.apps.whome.BROADCAST_IMMEDIATE_PERSONA to the _immediatePersonaBroadcastReceiver"!!!

 Which is what it does!

Of course, after a good shindig there is always something to clean up, so when the app is destroyed, we must also unregister the BroadcastReceivers, so that we don't leave the system holding some orphans that no longer have an app:

```
        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterReceiver(_immediatePersonaBroadcastReceiver);
            UnregisterReceiver(_relayablePersonaBroadcastReceiver);
            UnregisterReceiver(_regularPersonaBroadcastReceiver);
        }
```

If you have understood all of this, you are capable of recdeiving messages from any app that sends custom Broadcasts!

So, we now need to figure out how to send the received text in each of the three BroadcastReceivers, to an Azure Event Hub!

Just to recap, let's remember where in each BroadcastReceiver that we want to capture that information and send it.

As the structure of all three BroadcastReceivers is the same, I'll illustrate the ImmediatePersonaBroadcastReceiver:

```
    public class ImmediatePersonaBroadcastReceiver : BroadcastReceiver
    {
        ...

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC");

            _updater.UpdateMacroInfo(receivedText);

            // If you want to send this information over a network, create a service and pass the info to it here!
        }
    }
```

Well, the next step is obvious from the comments, let's create a service! For those of you following Path 1, this is where you start coding, so I'll change from descriptive prose to instructional.

The first thing that we have to do is decide what we want to replace the following line with:

```
            // If you want to send this information over a network, create a service and pass the info to it here!
```

So let's create a wish list! And let's keep it simple - we will let the service itself encapsulate all of the complexities!

We want:

* To filter out all messages that come from any Proximity Profile that is not our Custom one, that we created above
* To pass the received text to it

What we don't want to do here is deal with complexities like how to structure the data to send, what connection string to use. Its as simple as the two points above!

So let's create some psuedocode of what we want to do:

```
    _eventHubManager.Send(receivedText, "9c8eb14d-8c73-4399-bd0e-32ccd28066fa");  // Put the Persona Guid of your own Custom Profile here!
```

Ok, let's visualise an interface for that:

```
    public interface IMyAzureEventHubService
    {
        Task Send(string receivedSerialisation, string guidFilter);
    }
```

That looks sensible!

Btw, putting the Task in place of void allows us to prevent the program moving to the next line before the Send method completes.

At this point, the pseudocde above becomes:

```
        public async override void OnReceive(Context context, Intent intent)
        {
            ...

            await _eventHub.Send(receivedText, "9c8eb14d-8c73-4399-bd0e-32ccd28066fa");  // Put the Persona Guid you want to filter for, here! 
        }
```

Note that because I used the word await to force the program to wait until the Send method had finished, I had to add the word async to the method declaration!

So, here's the monkey-see-monkey-do:

Create a file in ```Services``` folder of the ```Xamarin Forms Project``` (not the Android one), and name it ```IMyAzureEventHubService```.

Replace any content of that file with the following:

```
using System.Threading.Tasks;

namespace WhoMeBroadcastReceiverViewer.Services
{
    public interface IMyAzureEventHubService
    {
        Task Send(string receivedSerialisation, string guidFilter);
    }
}
```

Next, create a class in the same folder called ```MyAzureEventHubService```.

Now, replace any content of that file with this:

```
using System;

namespace WhoMeBroadcastReceiverViewer.Services
{
    public class MyAzureEventHubService : IMyAzureEventHubService
    {
        public async Task Send(string receivedSerialisation, string guidFilter)
        {
            // this will presently error becuase we are not returning a task.
        }
    }
}

```

You can see that this is the MyAzureEventHubService class minimum structure - as it has an interface it MUST implement all of the methods that the interface declares, and in this case, the IMyAzureEventHubService interface declared the signature that you see above!

Next, go to the three of the BroadcastReceivers in the Android project, and:

* Add ```private IMyAzureEventHubService _eventHub;``` to the field declarations
* In the constructor of the class, get an instance of the ```IMyAzureEventHubService``` service, and assign it to the new ```_eventHub``` field that you just created.
* Add the ```async``` keyword to the ```OnReceive``` override
* Replace the commented-out text with the following: ```await _eventHub.Send(receivedText, "5d7944fb-bf62-4b6a-addd-d5ec176805ab");  // Put the Persona Guid you want to filter for, here!```

Each of the three BroadcastReceivers should look like this (but retaining their respective names):

```
    public class ImmediatePersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;
        private IMyAzureEventHubService _eventHub;

        public ImmediatePersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
            _eventHub = SimpleIoc.Default.GetInstance<IMyAzureEventHubService>();
        }

        public async override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC");

            System.Diagnostics.Debug.WriteLine("cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC");
            System.Diagnostics.Debug.WriteLine(receivedText);

            _updater.UpdateMacroInfo(receivedText);

            // If you want to send this infoamtion over a network, create a service and pass the info to it here!

            await _eventHub.Send(receivedText, "5d7944fb-bf62-4b6a-addd-d5ec176805ab");  // Put the Persona Guid you want to filter for, here! 
        }
    }
```

So now, I'm going to complete the service, and walk you through it. Most of it is what we call 'boiler-plate' code, and I'll explain each part as we do the walk-through.

First of all, replace the MyAzureEventHubService code with the following code:

```
    public class MyAzureEventHubService : IMyAzureEventHubService
    {
        private static EventHubClient eventHubClient;
        private const string EventHubConnectionString = "[Put your SHARED ACCESS POLICY SAS 'Hub Connection' String here!!!]";
        private const string EventHubName = "[Put thE NAME of your EVENT HUB here!!!!]";

        public MyAzureEventHubService()
        {
            // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
            // Typically, the connection string should have the entity path in it, but this simple scenario
            // uses the connection string from the namespace.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
            {
                EntityPath = EventHubName
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }

        public async Task Send(string receivedSerialisation, string guidFilter)
        {
            BroadcastInfoDic sharedModel = JsonConvert.DeserializeObject<BroadcastInfoDic>(receivedSerialisation);
            
            try
            {
                if (sharedModel.PersonaGuid.Equals(guidFilter))
                {

                    var eventHubDataTransmission = new EventHubModel(sharedModel.PersonaGuid, sharedModel.InfoDic);
                    var serialisedTransmission = JsonConvert.SerializeObject(eventHubDataTransmission);

                    Debug.WriteLine("EVENT HUB TRANSMISSION---------------------");
                    Debug.WriteLine(serialisedTransmission);
                    Debug.WriteLine("END---------------------");

                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(serialisedTransmission)));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
            }
        }

        public async Task CloseEventHubConnection()
        {
            await eventHubClient.CloseAsync();
        }
    }
```

Those of you who took Option 1 are not ready for the walk-through yet, and that is because at the moment they are seeing red-underlines, indicating errors, for the ```EventHubClient``` object!

The reason for this is that they haven't installed a specialised package that Microsoft has created that allows us to communicate directly with their Azure Event Hubs! Those who elected Option 2 already have it, but if you don't know how to install it, please don't skip this part!

In the Xamarin Forms project, expand the ```Dependencies``` folder, then expand the Nuget folder, we need to see there an object with the name ```Microsoft.Azure.EventHubs```.

To install that, right-click on the ```Nuget``` folder and select ```Manage Nuget Packages ...```

That will open a dialog box, and in the search field you should type the following:

```
Microsoft.Azure.EventHubs
```

That package should come to the top of the list - select it and then press the ```Add Package``` button. If it asks you to accept the licence, you must do so before you can install it.

For those on Option 1, the red lines should have gone away. If you have a slow system, just close the ```MyAzureEventHubService``` file and reopen it and things should look fine!

Right, now for the walk-through!!!

The first three lines of field declarations are boiler-plate code - that is, straight from Microsoft as a common pattern.

```
private static EventHubClient eventHubClient;
private const string EventHubConnectionString = "[Put your SHARED ACCESS POLICY SAS 'Hub Connection' String here!!!]";
private const string EventHubName = "[Put the NAME of your EVENT HUB here!!!!]";
```

Here we are given an Event Hub Client, and some connection variables. Ignore the connection variable strings for now, as we will get those from the Microsoft Azure Portal later!

The bottom method is also boiler-plate code:

```
public async Task CloseEventHubConnection()
{
    await eventHubClient.CloseAsync();
}
```

Microsoft wants us to properly close the connection when necessary, however if we want to use it in our service - for example, in the MainActivity OnDestroy() method where we unregister our BroadcastReceivers - then we will have to add it to the IMyAzureEventHubService signature! 

So let's digress from the MyAzureEventHubService walk-through and make the following quick changes in the IMyAzureEventHubService interface. We will come back to the MyAzureEventHubService's Send(...) method in a moment!

```
public interface IMyAzureEventHubService
{
    Task Send(string receivedSerialisation, string guidFilter);
    Task CloseEventHubConnection();
}
```

We haven't registered the IMyAzureEventHubService in our MainActivity, so let's do it now!

At the very top of the class, just above where we created the BroadcastReceiver fields, add the following line:

```
 private IMyAzureEventHubService _eventHubService;
```

Now, let's create that service, and register it with SimpleIoC:

Just below the line ```base.OnCreate(savedInstanceState);``` in the OnCreate(...) method, add the following lines of code:

```
_eventHubService = new MyAzureEventHubService();
if (!SimpleIoc.Default.IsRegistered<IMyAzureEventHubService>())
{
    SimpleIoc.Default.Register<IMyAzureEventHubService>(() => _eventHubService);
}
```

And the last thing to do is close the connection to the Event Hub in the OnDestroy() method:

```
await _eventHubService.CloseEventHubConnection();
```

And because we used the ```await``` keyword, don't forget to ad the ```async``` keyword to the method declaration!

Your MainActivity should now look like this:

```
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using GalaSoft.MvvmLight.Ioc;
using WhoMeBroadcastReceiverViewer.Droid.BroadcastReceivers;
using WhoMeBroadcastReceiverViewer.Services;
using WhoMeBroadcastReceiverViewer.ViewModels;
using Xamarin.Forms;

namespace WhoMeBroadcastReceiverViewer.Droid
{
    [Activity(Label = "Broadcast Viewer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private IMyAzureEventHubService _eventHubService;

        private ImmediatePersonaBroadcastReceiver _immediatePersonaBroadcastReceiver;
        private RelayablePersonaBroadcastReceiver _relayablePersonaBroadcastReceiver;
        private RegularPersonaBroadcastReceiver _regularPersonaBroadcastReceiver;

        private ImmediateViewModel _immediateViewModel;
        private RelayableViewModel _relayableViewModel;
        private RegularViewModel _regularViewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            _eventHubService = new MyAzureEventHubService();
            if (!SimpleIoc.Default.IsRegistered<IMyAzureEventHubService>())
            {
                SimpleIoc.Default.Register<IMyAzureEventHubService>(() => _eventHubService);
            }

            if (!SimpleIoc.Default.IsRegistered<ImmediateViewModel>())
            {
                SimpleIoc.Default.Register<ImmediateViewModel>(() => _immediateViewModel);
            }

            if (!SimpleIoc.Default.IsRegistered<RelayableViewModel>())
            {
                SimpleIoc.Default.Register<RelayableViewModel>(() => _relayableViewModel);
            }

            if (!SimpleIoc.Default.IsRegistered<RegularViewModel>())
            {
                SimpleIoc.Default.Register<RegularViewModel>(() => _regularViewModel);
            }

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnStart()
        {
            base.OnStart();

            _immediateViewModel = new ImmediateViewModel();
            _immediatePersonaBroadcastReceiver = new ImmediatePersonaBroadcastReceiver(this, (IUpdateMacroInfo)_immediateViewModel);

            IntentFilter immediateFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_IMMEDIATE_PERSONA");

            RegisterReceiver(_immediatePersonaBroadcastReceiver, immediateFilter);

            _relayableViewModel = new RelayableViewModel();
            _relayablePersonaBroadcastReceiver = new RelayablePersonaBroadcastReceiver(this, (IUpdateMacroInfo)_relayableViewModel);

            IntentFilter relayableFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_RELAYABLE_PERSONA");

            RegisterReceiver(_relayablePersonaBroadcastReceiver, relayableFilter);

            _regularViewModel = new RegularViewModel();
            _regularPersonaBroadcastReceiver = new RegularPersonaBroadcastReceiver(this, (IUpdateMacroInfo)_regularViewModel);

            IntentFilter regularFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_REGULAR_PERSONA");

            RegisterReceiver(_regularPersonaBroadcastReceiver, regularFilter);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterReceiver(_immediatePersonaBroadcastReceiver);
            UnregisterReceiver(_relayablePersonaBroadcastReceiver);
            UnregisterReceiver(_regularPersonaBroadcastReceiver);
        }

        internal void MakeToast(string receivedText)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Toast.MakeText(this, receivedText, ToastLength.Long).Show();
            });
        }
    }
}
```

So, all that is outstanding is finishing the ```Send(...)``` walk-through in the ```MyAzureEventHubService``` service!

```
        public async Task Send(string receivedSerialisation, string guidFilter)
        {
            BroadcastInfoDic sharedModel = JsonConvert.DeserializeObject<BroadcastInfoDic>(receivedSerialisation);
            
            try
            {
                if (sharedModel.PersonaGuid.Equals(guidFilter))
                {

                    var eventHubDataTransmission = new EventHubModel(sharedModel.PersonaGuid, sharedModel.InfoDic);
                    var serialisedTransmission = JsonConvert.SerializeObject(eventHubDataTransmission);

                    Debug.WriteLine("EVENT HUB TRANSMISSION---------------------");
                    Debug.WriteLine(serialisedTransmission);
                    Debug.WriteLine("END---------------------");

                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(serialisedTransmission)));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
            }
        }
```

The string parameter called ```receivedSerialisation``` is where we receive the text that is received by the BroadcastReceiver, and the ```guidFilter``` string, is where we receive the GUID of the persona that we want to filter for.

The first task at hand is to turn the text that we have received from the BroadcastReceiver, into an object. Because I know the structure of the text being received, I'll gtive this object to you as boiler-plate code. 

Create a class called BroadcastInfoDic in the Models directory of the Xamarin Forms project. Now paste in the following code:

```
using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class BroadcastInfoDic
    {
        public string PersonaGuid { get; set; }
        public Dictionary<string, string> InfoDic { get; set; }
        public SharedWhoMeProfile Persona { get; set; }
        public BroadcastInfoDic(string guid, SharedWhoMeProfile persona, Dictionary<string, string> infoDic)
        {
            PersonaGuid = guid;
            InfoDic = infoDic;
            Persona = persona;
        }
    }
}
```

This is the actual class that we used in the Who Me app to serialise the broadcasted text in the first place, so here we will reverse the process back to the original model!

The following line used JsonConvert to deserialsie the text back to an object:

```
BroadcastInfoDic sharedModel = JsonConvert.DeserializeObject<BroadcastInfoDic>(receivedSerialisation);
```

Now, we need to examine the Guid of that object, and see if it matches the one we are filtering on:

```
if (sharedModel.PersonaGuid.Equals(guidFilter))
{
    ...
}
```

The next thing that we need to do is create a JSON string of the data that we want to transmit to the event hub. The easiest way to do that is to create a model to hold our data, and then to user JsonConvert to serialise it!

Here, we'll create two different objects that are capable formating the data, to illustrate a couple of ways of doing it. The first will dump the whole dataset as two fields, the Guid and the rest. The second one will add all of the individual properties to individual fields in the event hub. The one that you would finally choose would depend upon the way you were doing your back-end aggregation, and personally, it's easier to grab the data dump than each of the individual properties, and just break it up into individual properties at the final destination where, for example, searches will actually be seeking out latitude and longitude.

So next, create a class called EventHubInfoDicModel in the Models directory of the Xamarin Forms project. Now paste in the following code:

```
using System;
using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class EventHubInfoDicModel
    {
        public EventHubInfoDicModel(string personaGuid, Dictionary<string,string> infoDic)
        {
            Guid = personaGuid;
            InfoDic = infoDic;
        }
        public string Guid { get; set; }
        public Dictionary<string, string> InfoDic { get; set; }
    }
}
```

And for the alternative, also create a file called EventHubPropertyModel in the same Models directory, and paste in the following code:

```
using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class EventHubPropertyModel
    {
        public string Guid { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string DroneName { get; private set; }
        public string FlightNumber { get; private set; }
        public string DroneId { get; private set; }
        public string DroneIdCountryCode { get; private set; }
        public string DroneSpeed { get; private set; }
        public string DroneHeading { get; private set; }
        public string DroneBarometricPressure { get; private set; }
        public string Timestamp { get; private set; }

        public EventHubPropertyModel(string personaGuid, Dictionary<string, string> infoDic)
        {
            var guid = string.Empty;
            var latitude = string.Empty;
            var longitude = string.Empty;
            var name = string.Empty;
            var flightNumber = string.Empty;
            var id = string.Empty;
            var idCountryCode = string.Empty;
            var speed = string.Empty;
            var heading = string.Empty;
            var pressure = string.Empty;
            var timestamp = string.Empty;

            infoDic.TryGetValue("", out guid);
            infoDic.TryGetValue("", out latitude);
            infoDic.TryGetValue("", out longitude);
            infoDic.TryGetValue("", out name);
            infoDic.TryGetValue("", out flightNumber);
            infoDic.TryGetValue("", out id);
            infoDic.TryGetValue("", out idCountryCode);
            infoDic.TryGetValue("", out speed);
            infoDic.TryGetValue("", out heading);
            infoDic.TryGetValue("", out pressure);
            infoDic.TryGetValue("", out timestamp);

            Guid = guid;
            Latitude = latitude;
            Longitude = longitude;
            DroneName = name;
            FlightNumber = flightNumber;
            DroneId = id;
            DroneIdCountryCode = idCountryCode;
            DroneSpeed = speed;
            DroneHeading = heading;
            DroneBarometricPressure = pressure;
            Timestamp = timestamp;
        }
    }
}

```

Now that we have those models created, we're done coding - other than for putting the connection string credentials into the code where the placeholders are!

But first, we need to finish our walk-through, by discussing the code that sits inside the Guid filter:

```
if (sharedModel.PersonaGuid.Equals(guidFilter))
{
    string jsonString = string.Empty;

    // Comment out either the next three lines, or the following three lines!

    // Event Hub Property Model serialisation
    /*
    var eventHubInfoDicDataTransmission = new EventHubInfoDicModel(sharedModel.PersonaGuid, sharedModel.InfoDic);
    var serialisedEventHubInfoDicDataTransmission = JsonConvert.SerializeObject(eventHubInfoDicDataTransmission);
    jsonString = serialisedEventHubInfoDicDataTransmission;
    */

    // Event Hub Info Dictionary serialisation
    var eventHubPropertyDataTransmission = new EventHubPropertyModel(sharedModel.PersonaGuid, sharedModel.InfoDic);
    var serialisedEventHubPropertyDataTransmission = JsonConvert.SerializeObject(eventHubPropertyDataTransmission);
    jsonString = serialisedEventHubPropertyDataTransmission;

    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(serialisedEventHubPropertyDataTransmission)));
}
```

As you can see, we have the data that we have received in the sharedModel object, so now we need to serialise it, using JsonConvert.

The first three lines (commented out), ingresses each property in the Persona, into it's own column in the database.

The second three lines (not commented out), ingresses the guid, and a single dump of the InfoDic, straight into the event hub, a total of two colums.

As implied earlier, if you had various worker roles just grabbing all of the information and putting it in another destination, then perhaps the second option would be best. The worker role itself can parse the data and put it in the individual columns in the database, when it does the work.

Alternatively, if you needed to sort by data-query from the Event Hub directly, such as by latitude and longitude, the first option would be better.

Having said that, you can actually sort on the fields of the data dump, as it is in strict JSON format, so your method would depend upon your architect, and needs, at the time!

Another reason for going for the datadump, by Guid, is that you are not tieing yourself into creating a Companion App that would be specific to one Persona. You could create a Text Boxes in a Settings Page, to paste the connection credentials, as well as Guid, and that solution would suit every persona that you could ever create. You could even add multiple Guids and multiple Connection Credentials, to service multiple Event Hubs! If a 64 K computer sent men to the Moon, with the power of modern and future handsets, where is Who Me taking us!

I suspect that feature will be in version 2 of the Who Me Broadcast Viewer, or perhaps broken out as a seperate utility app.

Before we start looking at the Azure Portal to create an Event Hub, I'd like to make an important note about the app, as presented.

We have specifically coded how we send the Broadcasts to these BroadcastReceivers, so that the Companion App has to be open, for it to be used. We can, of course, add a feature so that the Companion App doesn't have to be open, but will still send the information to the Event Hub when the Android Operating System receives broadcasts from the Who Me app.

This is a wonderful opportunity, but we are not going to introduce it until the Who Me Cloud is up and running, and the reason is that we want to prevent rogue apps from sniffing the information. If an app has to be open to receive the broadcasts, the user is more likely to notice a rogue app being open.

However when we have the Who Me Cloud up and running, both the Who Me app, and the Companion App, will be able to download suitable encryption keys from the Who Me Cloud, to make sure that any closed app that is trying to sniff the broadcasts despite being closed, will not be able to decrypt the messages.

I hope that you catch the vision of how amazing the prospect of multiple Companion Apps being available to act upon specific Personas. I hope that this represents the birth of a new industry!

# 5 Create a Microsoft Azure Event Hub

The rest is quite straight forward. All we have to do is create an event Hub using the Portal Console Tools, copy and paste the connection credentials into the Companion App, start the Who Me App up in Discovery Mode with the sending ```FAA Compliant UAV Traffic Management (V1)``` Proximity Profile activated, and then go back into the Event Hub Portal and watch the data come in!

If you don't have a Microsoft Azure Account, you can get one here for free, and with free credits that are huge!

https://azure.microsoft.com/en-gb/free/

Once you are logged in, look for tap on the ```+ Create``` button on the left hand side.

Tapping on the ```+ Create``` button will have brought you to this ```New``` screen.

![](assets/1.png "")

Type the words ```Event Hubs``` in the search box and tap on the Even Hubs Result.

![](assets/2.png "")

Tappinbg on the ```Event Hubs``` result will have brought you to a screen where you can tap on the ```Create``` button.

![](assets/3.png "")

Having tapped on the ```Create``` button, you will be presented with a screen and asked to create a namespace. As you can see in the picture, this creates a url that is your namespace URL. We created a namespace of ```faademonamespace```

![](assets/4.png "")

Once you have created a namespace, you will have a few items to complete. In the pricing tier, go for the cheapest, even if you are on a free account.

![](assets/5.png "")

Then you will be asked to create a Resource Group. Tap on ```Create New``` here and write down on a piece of paper the name of the Resource Group.

I can't stress enough how much you need to remember this name. At the end of the demo, you will delete this resource group, and when you delete it, everything else that is attached to it will also be deleted. If you have a paid account and forget to delete this, your bill will creep up, day by day!

Here's a tip - include the words ```ResourceGroup``` at the end of the name.

![](assets/6.png "")

We called our Resource Group by the name ```faademoresourcegroup```

![](assets/7.png "")

Now choose a location for your event hub. Scroll the list until you find something close.

We chose ```UK West```.

Then tap the ```Create``` button. All you have done so far is create a ```namespace```

![](assets/8.png "")

![](assets/9.png "")

Once the namespace has been created, you will be presented with a screen to create an Event Hub. Bravo, we are almost here!

![](assets10.png "")

![](assets/11.png "")

Having tapped the ```Create``` Events hub button, you will be taken to a screen where you actualy crerate your event hub. Tap the ```+ Event Hub``` button.

![](assets/12.png "")

First, give the Event Hub a name. We called ours ```faademoeventhub```

![](assets/13.png "")

Once you have named the event hub, click the ```Create``` button at the bottomn of the screen.

![](assets/14.png "")

In the next screen, click on the ```Shared Access Policies``` button in the left menu.

You will see a label that says ```no policies have been set up yet```

Tap on the ```+ Add``` button.

![](assets/15.png "")

You will now be presented with a screen that says ```Add SAS Policy```. We need to add this to get our connection credentials.

Give the SAS Policy a name. We called ours ```faademosas```

Then check all the boxes ```manage```, ```send```, ```listen```.

This means that anything that uses the connection credentials that we will get, can manage the event hub, send to it, and listen for things from it.

Press ```Create``` at the bottom of the screen.

![](assets/17.png "")

You will now see the SASD Policy in the list where the words ```no policies have been set up yet``` used to be.

Click on that new item!

![](assets/18.png "")

You will be taken to a screen that has your connection credentials on the far right of the page.

Copy the ```connection string primary-key``` into your clip-board.

![](assets/19.png "")

For the moment, minimise your browser and go back to Visual Studio, to the file called ```MyAzureEventHubService```.

Here, you should paste your connection string as shown!

Also, paste the ```Event Hub Name``` into the ```EventHubName``` property.

Once you have added the connection credentials, you are ready to build the Companion App.

Here, you will have to do a little research to see how to connect your specific model to Visual Studio.

Once the Companion App is up and running, then start the Who Me app. 

You want them both running at the same time!

Swipe across to the ```Sending``` Tab and tap the persona thaty says ```FAA Compliant UAV Traffic Management (V1)```

![](assets/20.png "")

That last action will have opened the persona in the ```Sending Editor```.

![](assets/p1.jpg "")

Scroll down and fill out the ```Flight Number```, ```Drone Id```, and select your country code from the ```Country Code Picker```.

![](assets/p2.jpg "")

Here's a tip about the drone id - and what you do will depend upon your own country's localisation.

Here in the UK, every drone has a ```Drone Operator``` registration number, and every Remote Pilot has a Flyer Id.

My Operator Id is ```OP-2YQ3BWZ```, and as it turns out, every Operator Id starts with the letters ```OP-```. So as the drone belongs to an 'operator', I chop off the redundant ```OP-``` to preserve transmission space, and then append a unique drone Id to my operator Id.

So my number 1 drone's Id is ```2YQ3BWZ-1```, my number 2 drone's Id is ```2YQ3BWZ-2```, and so forth.

Then in the next field, the Drone Id Country Code, I select the country code for my Operator Code - which was issued in ```GB```.

Suddenly my drone has an authentic and unique Drone Id that anyone can trace back to me!

![](assets/p3.jpg "")

Next, dismiss that screen by tapping the back button, make sure the persona is activated, and switch the discover Service button at the top right hand side to ON.

![](assets/p4.jpg "")

At this point the Who Me app will start broadcassting your Persona, and if you bring the Companion App to the front, you will be able to see what the app is broadcasting, on the ```Immediate``` tab.

![](assets/p5.jpg "")

So let's go back to the Azure Portal, to the Event Hub page, and tap on the ```Process Data``` button.

![](assets/21.png "")

That will take you to an ```Explore``` button, tap on that.

![](assets/22.png "")

Here, you will see that I've created a specific data query, as follows:

```
SELECT
    InfoDic.[1] as latitude,
    InfoDic.[2] as longitude,
    InfoDic.[A] as flightnumber,
    InfoDic.[B] as droneid,
    InfoDic.[C] as droneidcountrycode,
    InfoDic.[D] as altitude,
    InfoDic.[E] as speed,
    InfoDic.[F] as heading,
    InfoDic.[G] as barometricpressure,
    InfoDic.[H] as ticks,
    EventProcessedUtcTime

INTO
    [OutputAlias]
FROM
    [faademoeventhub]
```

And hey presto, there's a nice looking event hub!

![](assets/data.png "")

If you compare the raw results with the blue screen above that showed the raw data, you will see the original InfoDic that I turned into a query, here in Microsoft's Azure Event Hub!

Fabulous!

![](assets/data2.png "")

