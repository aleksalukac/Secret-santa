# importing the module
import json
import random

import smtplib, ssl

# Opening JSON file
with open('users.json') as json_file:
    port = 587  # For starttls
    smtp_server = "smtp.gmail.com"
    sender_email = "secretsanta.rtc.ns@gmail.com"
    password = "RtcNoviSad2021"

    #read names from json
    data = json.load(json_file)

    shuffled_keys = list(data.keys())
    random.shuffle(shuffled_keys)

    for i in range(len(shuffled_keys)):
        j = i + 1
        if(j == len(shuffled_keys)):
            j = 0

        receiver_email = shuffled_keys[i]
        message = "Tvoj secret santa je " + data[shuffled_keys[j]]

        context = ssl.create_default_context()
        with smtplib.SMTP(smtp_server, port) as server:
            try:
                server.ehlo()  # Can be omitted
                server.starttls(context=context)
                server.ehlo()  # Can be omitted
                server.login(sender_email, password)
                server.sendmail(sender_email, receiver_email, message)
            except Exception as e: print(e)