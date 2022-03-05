
![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2022

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
- [Entry form template](ENTRYFORM.md)
- [Starter kit instructions](STARTERKIT_INSTRUCTIONS.md)

We had it working in pieces but it just didn't come together in time, unfortunately.
We don't have a working solution but we wanted to check it in to share with each other.
Thanks for volunteering to judge.


# Hackathon Submission Entry form

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team name
Lady Verndalians

## Category
Best addition to the Sitecore MVP site

## Description

Unless you have been living under a rock recently, you know that Content is trending! Providing high quality content and a smart way to access that content is important for all businesses. It helps attract clients and create interest.  Also, having a site that is accessible is mandatory.
Our module provides a search page for the MVP Get to Know an MVP podcasts that exposes the content in the audio file.  It transcribes podcasts in the Content Editor and retains the transcription.  While utilizing Microsoft Cognitive Services Speech To Text API, the task is run as a background job to not disrupt the content author.

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

[Lady Verndalians Video](https://github.com/Sitecore-Hackathon/2022-Lady-Verndalians/blob/develop/Lady%20Verndalians%20Hackathon%202022%20Video.mp4)


## Pre-requisites and Dependencies

 - Install-Package Microsoft.CognitiveServices.Speech -Version 1.20.0 if it doesn't self-install

## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

- Sign up for Microsoft Cognitive Services: [Start Free](https://azure.microsoft.com/en-us/free/cognitive-services/)
- Open the solution.
- Add the license key and your assigned region to the Foundation.CognitiveServices app.Config file
 - Install-Package Microsoft.CognitiveServices.Speech -Version 1.20.0 if it doesn't self-install
 - Build
 - Use the Sitecore Installation wizard to install the [package](#link-to-package)


### Configuration

 - Sign up for Microsoft Cognitive Services: [Start Free]
 - Add the license key and your assigned region to the Foundation.CognitiveServices app.Config file

## Usage instructions

 - Create Podcast Detail pages from this template: [  
/sitecore/templates/Project/Pages/Podcast Detail](https://hackathon2022sc.dev.local/sitecore/shell/Applications/Content-Editor?ic=Apps%2F48x48%2FPencil.png&he=Content%20Editor&cl=0#)
 - Enter the Podcast Name and https:// file path for the .mp4 file (from Core Sampler, for example).

Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)

## Comments
If you'd like to make additional comments that is important for your module entry.

