## Inspiration 💡
Cycling is a hobby of many Canadians. But winter or rainy seasons could stop us from riding on our lovely bikes and enjoying the surrounding world. Beside, Covid-19 also one of the factor that people could not ride bike to work/school which statically has risen mental health issue in Alberta. Knowing the struggle, our team tends to keep up the spirit by developing a VR integrated application which can simulate the experience.

## What it does 💥
We makes use of the **VR technology - Oculus VR** to simulate the riding motions which helps user move to desired location and VR will provide the 3D real-world surrounding. This will give us the most realistic experience regards to cycling activity.

## How we built it 🔨
Oculus collects movement and events, then sends to Unity where it triggers the scripted action corresponding to that event, then action will be rendered from Unity and send back to Oculus where user will see. 
We separately built the environment and components. When building the environment, we did a deep research on which API provider should we use. After a hard time considering between **Esri, Microsoft Bing and Google Map**, we decided to stick with **Google Map**, though the technology is stated to be deprecated. After that, we generated **API key** connects with the provider to get the runtime map, and rendered onto Unity. 
Meanwhile, the other team will take care of implementing the main components. This process includes writing scripts according to its events as well as organized the layers of the 3D components so that things are controlled as expected. 
During every process, teams tested frequently with the Oculus device to ensure the User experience aligned with our requirements.

## Challenges we ran into 🗻
We faced a lot technical adaption and learning upon the completion of the project:
- The process of **selecting map provider** was tedious since every provider has pros and cons.
- The **initial set up** connecting **Joysticks to Unity** was hard for us since Unity updates consistently so we need to update ourselves with not only the newest Youtube tutorials but also the previous ones to understand the basics.
- Working with **3D environment** was an interesting experience, we need to consider Math & Physics knowledge in every decision in order to achieve the expectation.

## Accomplishments that we're proud of :🏁
Although everyone was new with the technology and the 3D idea, we manage to work together as a team. We planned, we learnt, we disappointed and we celebrated. 

## What we learned 🎓
- The best way to improve is to step in uncomfortable area, in this case, Unity with Oculus and Google Maps SDK are the new land for our team.
- We learnt to control 3D components, use 3D interaction library. 

## What's next for CycleVR 🚧
- Next step for CycleVR is to add new components so that the virtual environment more realistic. We will try to improve our oscillation algorithm for the Joystick to enhance User Experience.

## Video Demo
https://youtu.be/0ZyBEswHsYY
