# Table of Contents
- [Table of Contents](#table-of-contents)
- [Overview](#overview)
  - [The Animal Data Tool](#the-animal-data-tool)
  - [Quick Links](#quick-links)
  - [Resources](#resources)
  - [Images Used](#images-used)
  
# Overview

*Last Updated 7.29.2021*
* Started: 7.23.2021
* Unity version used: 2020.3.14f1
* Main goal: Create a UI based off of JSON data.

For the sake of this simple example, I kept the images and JSON data all local within the Asset folder. 

Using the data within the JSON file, I create rows of different animals. At the moment it's restricted to Dogs, Cats, and Lizards. The page itself scrolls vertically while each row scrolls horizontally. Tapping on an animal card will show a modal with "More Info".

The example's **Start** function is in [AppManager.cs](https://github.com/moose15/code-sample-1/blob/main/AnimalCardRows/Assets/_Scripts/AppManager.cs). 

<p float="left" align="center">
  <img width="200" alt="CodeSampleOne_01" src="https://user-images.githubusercontent.com/4196059/127598337-097cd6f5-8767-41e6-a1c8-534b3c733c2e.png">
  <img width="200" alt="CodeSampleOne_02" src="https://user-images.githubusercontent.com/4196059/127598347-04b4d52f-cb89-40fe-a0e8-773476ba39f3.png">
  <img width="200" alt="codeSampleOne_03" src="https://user-images.githubusercontent.com/4196059/127598349-9b11d186-94cc-4d85-b5b8-278bca5f3660.gif">
</p>

## The Animal Data Tool
As a part of this sample, I also created a Unity editor tool to help create the data for the AnimalData JSON file.

**Scripts involved:**
* [AnimalDataEditor.cs](https://github.com/moose15/code-sample-1/blob/main/AnimalCardRows/Assets/_Scripts/Editor/AnimalDataEditor.cs)
* [Animal.cs](https://github.com/moose15/code-sample-1/blob/main/AnimalCardRows/Assets/_Scripts/Animal.cs)
* [AnimalDataHandler.cs](https://github.com/moose15/code-sample-1/blob/main/AnimalCardRows/Assets/_Scripts/AnimalDataHandler.cs)

<p align="center">
<img width="400" alt="codeSampleOne_04" src="https://user-images.githubusercontent.com/4196059/127438538-0388204e-b7fe-46e9-8ee3-66b2e7399239.png">
</p>

## Quick Links
* [Scripts Folder](https://github.com/moose15/code-sample-1/tree/main/AnimalCardRows/Assets/_Scripts)
* [Animal Data JSON file](https://github.com/moose15/code-sample-1/blob/main/AnimalCardRows/Assets/Resources/AnimalData.json)

## Resources
* [Unity UI Extensions](https://bitbucket.org/UnityUIExtensions/unity-ui-extensions/wiki/Home)
   * ScrollConflictManager and Gradient2 are from this repository.
* [DOTween library](http://dotween.demigiant.com/) 
   * I used this library to animate the buttons and modal. 
* The Lato Font used is from [Google Fonts](https://fonts.google.com/) 

## Images Used
* Husky: https://pixabay.com/photos/husky-dog-dog-breed-animal-3380548/
    * Image by <a href="https://pixabay.com/users/pixel2013-2364555/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=3380548">S. Hermann &amp; F. Richter</a> from <a href="https://pixabay.com/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=3380548">Pixabay</a>
* Corgi: https://pixabay.com/photos/dog-pet-corgi-animal-canine-6394502/
    * Image by <a href="https://pixabay.com/users/molnarszabolcserdely-2742379/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=6394502">Szabolcs Molnar</a> from <a href="https://pixabay.com/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=6394502">Pixabay</a>
* Cat with Flower: https://pixabay.com/photos/kitty-playful-flowers-wildflowers-2948404/
    * Image by <a href="https://pixabay.com/users/ilyessuti-3558510/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=2948404">Ilona Ilyés</a> from <a href="https://pixabay.com/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=2948404">Pixabay</a>
* Black Cat: https://pixabay.com/photos/cat-black-animals-pet-feather-3169476/
    * Image by <a href="https://pixabay.com/users/nhudaibnumukhtar-8022978/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=3169476">Huda Nur</a> from <a href="https://pixabay.com/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=3169476">Pixabay</a>
* Green Gecko: https://pixabay.com/photos/lizard-madagascar-day-gecko-scale-2732989/
    * Image by <a href="https://pixabay.com/users/moonzigg-6341937/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=2732989">moonzigg</a> from <a href="https://pixabay.com/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=2732989">Pixabay</a>
* Brown Lizard: https://pixabay.com/photos/iguana-florida-lizard-dragon-4835983/ 
    * Image by <a href="https://pixabay.com/users/wurliburli-14850337/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=4835983">wurliburli</a> from <a href="https://pixabay.com/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=4835983">Pixabay</a>
* The 'X' icon is by Aybige from [thenounproject](https://thenounproject.com/)
