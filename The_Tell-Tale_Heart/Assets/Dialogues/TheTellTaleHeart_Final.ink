VAR playerHP = 3

-> Question_1

== Question_1 ==
Sorry to bother you this late, sir. #speaker:Police #layout:Layout_SpeakerPanel_Left

* Oh, it's not a problem, officers. Please make yourself at home. #speaker:Player #layout:Layout_SpeakerPanel_Right
    Thank you for understanding, sir. #speaker:Police #layout:Layout_SpeakerPanel_Left
    
* Seriously, what is wrong with you?! #speaker:Player #layout:Layout_SpeakerPanel_Right
    No need to get so hostile, sir. #speaker:Police #layout:Layout_SpeakerPanel_Left
    
    ~ playerHP -= 1
    
- -> Question_2

== Question_2 ==
You see, sir, the neighbor called us due to a strange loud noise coming from this house. #speaker:Police #layout:Layout_SpeakerPanel_Left

* That's none of their business! #speaker:Player #layout:Layout_SpeakerPanel_Right
    Sir, I ask you to cooperate with us! #speaker:Police #layout:Layout_SpeakerPanel_Left
    
    ~ playerHP -= 1
    
* Oooh, that sound. It was me. You see, I suffered from a nightmare so I couldn't help but scream. #speaker:Player #layout:Layout_SpeakerPanel_Right
    I see... Nightmare can be very painful. #speaker:Police #layout:Layout_SpeakerPanel_Left

- -> Question_3

== Question_3 ==
Isn't this the old man's house, sir? How has he been lately? #speaker:Police #layout:Layout_SpeakerPanel_Left

* He is dead. #speaker:Player

~playerHP -= 1

    Excuse me? #speaker:Police #layout:Layout_SpeakerPanel_Left
    
    **I was joking, officers. I mean he's sleeping like the dead. As you can see, the house is undisturbed! #speaker:Player #layout:Layout_SpeakerPanel_Right
    
        You are quite a jokester, sir. #speaker:Police #layout:Layout_SpeakerPanel_Left
        
    **Didn't you hear me? He's DEAD!!! Yet how can I still hear his heart...? #speaker:Player #layout:Layout_SpeakerPanel_Right
    
    ~ playerHP -= 1
    
* He's fine, officers. Healthy even! #speaker:Player #layout:Layout_SpeakerPanel_Right
    That's nice. I always thought he looks rather sickly. #speaker:Police #layout:Layout_SpeakerPanel_Left
    
    **Of course, he's sick because of that disgusting eye! #speaker:Player #layout:Layout_SpeakerPanel_Right
    
        Sir, it's just an artificial eye. #speaker:Police #layout:Layout_SpeakerPanel_Left
        
        ~playerHP -= 1
        
    **I believe it's just old age, officers. You can't judge a book just based on its cover, don't you think so? #speaker:Player #layout:Layout_SpeakerPanel_Right
    
        How right you are, sir. #speaker:Police #layout:Layout_SpeakerPanel_Left

-{playerHP <= 0:
    Sir, you have been acting very suspicious thus you are under arrest for suspicious activity! Please come with us, now! #speaker:Police #layout:Layout_SpeakerPanel_Left
    ->END
    
  - else:
    -> Question_4
}

== Question_4 ==
This house sure is very cozy. #speaker:Police #layout:Layout_SpeakerPanel_Left

* Can you hear something, officers? #speaker:Player #layout:Layout_SpeakerPanel_Right
    No, not really, sir? #speaker:Police #layout:Layout_SpeakerPanel_Left
    
    ~playerHP -= 1
    
* It sure is. Would you believe this house is already 89 years old? #speaker:Player
    My, really? #speaker:Police #layout:Layout_SpeakerPanel_Left
    
    **I swear I can hear something... #speaker:Player #layout:Layout_SpeakerPanel_Right
    
    ~playerHP -= 1
    
        Are you alright, sir? #speaker:Police #layout:Layout_SpeakerPanel_Left
        
        *** No, I'm not!!! This sounds it's deafening! #speaker:Player #layout:Layout_SpeakerPanel_Right
        
        ~playerHP -= 1
        
        *** I... don't know... But I can hear it! #speaker:Player #layout:Layout_SpeakerPanel_Right
        
        ~playerHP -= 1
        
    ** I didn't believe it as well! I mean the quality of the building is still very top-notch. #speaker:Player #layout:Layout_SpeakerPanel_Right

-{playerHP <= 0:
    Sir, you have been acting very suspicious thus you are under arrest for suspicious activity! Please come with us, now! #speaker:Police #layout:Layout_SpeakerPanel_Left
    ->END
    
  - else:
    -> Question_5
}

//Q5 is where you are guaranteed to fail
=== Question_5 ===
I believe we have taken enough of your time, sir #speaker:Police #layout:Layout_SpeakerPanel_Left

* I see... Say, officers, do you hear something? #speaker:Player #layout:Layout_SpeakerPanel_Right

~playerHP -= 1

    No sir... I think you should just get some fresh air and a good sleep. It has been a long night after all. #speaker:Police #layout:Layout_SpeakerPanel_Left
    
    **No, I mean it! These beating sounds... like a heartbeat...! #speaker:Player #layout:Layout_SpeakerPanel_Right
    
    ~playerHP -= 1
    
    **How can you not hear it? These beating sounds are so damn LOUD!!! #speaker:Player #layout:Layout_SpeakerPanel_Right
    
    ~playerHP -= 1
    
* Uhm... Officers, don't you feel something is wrong? #speaker:Player #layout:Layout_SpeakerPanel_Right

~playerHP -= 1

    Besides us being called to work this late, I believe everything is fine, sir. #speaker:Police #layout:Layout_SpeakerPanel_Left
    
    ** You sure you can't hear something? These sounds... #speaker:Player #layout:Layout_SpeakerPanel_Right
        It's too loud!!! #speaker:Player #layout:Layout_SpeakerPanel_Right
        
        ~playerHP -= 1
        
    ** Your ears are working, right? Why can't you hear these beating sounds like I do? You must have hear it clearly! #speaker:Player #layout:Layout_SpeakerPanel_Right
        My ears!!! #speaker:Player #layout:Layout_SpeakerPanel_Right
        
        ~playerHP -= 1

-{playerHP <= 0:
    That's it! I confess!!! I killed the old man! I chopped him up and hide each body part. His heart is right down here! THEN TELL ME HOW I CAN STILL HEAR HIS HEART BEATING??? #speaker:Player #layout:Layout_SpeakerPanel_Right
    ->END
    
  - else: That's it! I confess!!! I killed the old man! I chopped him up and hide each body part. His heart is right down here! THEN TELL ME HOW I CAN STILL HEAR HIS HEART BEATING??? #speaker:Player #layout:Layout_SpeakerPanel_Right
    -> END
}
-> END