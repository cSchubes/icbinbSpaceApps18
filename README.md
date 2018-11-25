# I Can't Believe It's Not Butter, International SpaceApps 2018

[Official Project Page](https://2018.spaceappschallenge.org/challenges/can-you-build/design-based-nature-fusion/teams/i-cant-believe-its-not-butter/project)

![alt text](20181021_155709.jpg)

## The Problem
Since the earliest days of spaceflight the ability to view your craft from a third-person view during flight has been dreamed of. Sadly, NASA knows all too well the difficulties that arise without this capability - from Apollo 13 to Columbia, this technology stands to drastically improve astronaut and asset safety.

Recent advances in image processing, autonomous vehicles, and small satellite technology have turned what was once a dream into a problem ready to be solved. There is no longer any excuse - the time is now to take this next step in our space journey.

## Our Approach

As a diverse team of various engineering, computer science, and non-technical backgrounds we decided to take a multi-pronged approach to solving this problem. At the core of our solution is the idea of an MVP, or Minimum Viable Product. An MVP is the most basic product you can build which still has all of the required functionality of the system. Our aim with this approach is to find a solution which produces a real increase in astronaut safety as quickly as possible. To accomplish this we worked in parallel on a three part solution.

## Part 1: Concept Design and Technology Study

The first step was to define the minimum requirements of an autonomous free-flyer capable of inspecting a spacecraft. We posed questions to ourselves such as:

What type of sensor suite is necessary for full autonomy?
How large would such a free-flyer need to be?
How does it move around in space?
What safety protocols are necessary to prevent the free-flyer itself from damaging the spacecraft?
These questions led the team toward a conceptual design for a 3U CubeSat, built in Autodesk Inventor and pictured here.

In recent years CubeSats have become significantly cheaper to produce as major players such as Tyvak have commercialized the market space. This, in addition to the benefits of using a standardized form factor, made a CubeSat design the obvious choice.

We then performed a technology study to determine which technology necessary for the system is ready for flight, and where more development is still needed. The outcome of this study was very positive: nearly all of the technology necessary is mature enough to fly in the near future.

As a final measure, we developed an Activity Diagram (shown here) which outlines, step by step, our vision for how the free-flyer and supporting systems would operate during the mission. The diagram is comprised of 'swim lanes' that represent all participating systems or subsystems. Every action taken during the mission falls under the responsibility of one system and is placed in that system's 'swim lane'. The key takeaway from this diagram is the lack of crew interaction - they merely kick off the process, and receive the final results at the very end.

## Part 2: Damage Detection Prototype
The core mission of an autonomous free-flyer would be to inspect the spacecraft for micro meteoroid and orbital debris damage prior to re-entry, where this damage can cause serious problems. We propose to solve this problem of damage detection using state-of-the-art image classification enabled by Convolutional Neural Networks. To show that this technology is ready for flight right now, we built a simple damage detector using PyTorch.

For our MVP solution, we limited our damage classifier to detection only: simply safe or unsafe. We envision a system by which a spacecraft's outer body is segmented into sections of appropriate size which the free-flyer navigates to and images. These images are run through the damage detector running onboard the free-flyer. At the conclusion of its inspection run around the entirety of the spacecraft, classifications for each section are downloaded to the spacecraft and displayed in an easy to understand format which highlights any areas marked as unsafe. The image associated with each unsafe classification will be displayed as well to allow astronauts and ground crew to manually inspect a suspected problem area to determine the validity and extent of the damage.

In this system, a spacewalk could be required to further investigate the damaged area. Although this is not ideal, by limiting our free-flyer to only image its predetermined sections with no specific characterization of damaged areas we significantly reduce the complexity of autonomous operations while still providing a marked increase in safety. This tradeoff is acceptable for version one of the system.

Using transfer learning (taking a pretrained network and simply retraining its final classification layer) we were able to train an effective damage detector using only 547 images. Lacking a good dataset of real micro meteoroid damage on spacecraft, we opted to use images of bullet holes and impacted metal for the majority of the unsafe dataset. The safe dataset was composed of undamaged spacecraft, planes, cars, and other metallic objects.

The final results are described here. We were able to achieve an overall accuracy of 95.89% on the validation set (images the network had never seen before) with only a 2.27% false negative rate. As the 'Classification Accuracy' graphic shows, we prioritize a low false negative rate at the expense of a higher false positive rate. This bias is critical for a system so important to astronaut safety; as the saying goes, it's better safe than sorry.

## Part 3: Full System Visualization

Tying the entire project together is a visualization created using Unity which showcases our vision for the full system in action.

We created a simulation to demonstrate the interaction between the ship, the astronaut and the free flyer. In the simulation, we assume the role of an astronaut. We are able to access a simple panel and initiate an inspection sequence.

Once the process has been initiated, the astronaut is able to view a screen that displays what the free flyer is inspecting. Without further action, the free flyer is able to complete it's inspection while the astronaut can perform other tasks.

When the inspection is done, a hologram appears for the astronaut to view. The hologram is a 3D model of the ship that highlights all places of interest. Unsafe areas are marked in red while areas deemed safe are marked in green.

## Conclusion

Taken together, these three components form the foundation of an MVP free-flyer. Next steps would include:

1. Obtain and train on simulated images captured within the visualization.
2. Determine hardware requirements for running the autonomous algorithms and damage detector onboard the free-flyer.
3. Add virtual reality capabilities to the visualization to further showcase our vision for the system.  

Autonomous free-flyers stand to revolutionize astronaut and asset safety. We hope our project can be used as a starting point for making this technology standard on every NASA vehicle.
