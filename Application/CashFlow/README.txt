THIS PROJECT USE VISUAL STUDIO ONLINE TO CI/CD IN DIT ENV AUTOMATICALLY
	REQUEST A PR TO DEVELOP BRANCH TO TRIGGER THE BUILD AND DEPLOY

RUNNING IN DEBUG
	USE IIS EXPRESS
	http://localhost:44344/

database:
	server: mc2tech.database.windows.net
	catalog: cashflow
	user: cashflow_webapp
	pass: CFWA@2018

only one database have been deployed because cost of enviroment

Users:
	user:manager
	pass:Boss123

	user:employee
	pass:Employee123

Authentication of this web application use Azure B2C service that integrate with internal ActiveDirectory and is able to integrate with others providers like Microsoft Account, facebook, linkedin, etc...

Colors used

	light
		rgb(207, 229, 255)

	light marked
		rgb(86, 154, 255)
		rgb(78, 167, 243)

	dark
		rgb(42, 63, 143)