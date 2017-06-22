namespace sync_addin_for_outlook_and_jira

open FSharp.Data

module Types = 
    module JIRA =
        type internal Issues = JsonProvider<""" {"expand":"schema,names","startAt":0,"maxResults":50,"total":5,"issues":[{"expand":"operations,versionedRepresentations,editmeta,changelog,renderedFields","id":"10006","self":"https://a.hsharp.software/rest/api/2/issue/10006","key":"SVCZ-3","fields":{"issuetype":{"self":"https://a.hsharp.software/rest/api/2/issuetype/10104","id":"10104","description":"A problem which impairs or prevents the functions of the product.","iconUrl":"https://a.hsharp.software/secure/viewavatar?size=xsmall&avatarId=10303&avatarType=issuetype","name":"Bug","subtask":false,"avatarId":10303},"timespent":null,"project":{"self":"https://a.hsharp.software/rest/api/2/project/10001","id":"10001","key":"SVCZ","name":"Support pro VCZ Outlook Addin SAP B1 Sync","avatarUrls":{"48x48":"https://a.hsharp.software/secure/projectavatar?avatarId=10324","24x24":"https://a.hsharp.software/secure/projectavatar?size=small&avatarId=10324","16x16":"https://a.hsharp.software/secure/projectavatar?size=xsmall&avatarId=10324","32x32":"https://a.hsharp.software/secure/projectavatar?size=medium&avatarId=10324"}},"fixVersions":[],"aggregatetimespent":null,"resolution":{"self":"https://a.hsharp.software/rest/api/2/resolution/10000","id":"10000","description":"Work has been completed on this issue.","name":"Done"},"resolutiondate":"2017-06-03T16:52:58.000+0200","workratio":-1,"lastViewed":"2017-06-03T16:53:07.679+0200","watches":{"self":"https://a.hsharp.software/rest/api/2/issue/SVCZ-3/watchers","watchCount":1,"isWatching":true},"created":"2017-05-26T16:43:34.000+0200","priority":{"self":"https://a.hsharp.software/rest/api/2/priority/3","iconUrl":"https://a.hsharp.software/images/icons/priorities/medium.svg","name":"Medium","id":"3"},"customfield_10100":[],"customfield_10101":{"_links":{"jiraRest":"https://a.hsharp.software/rest/api/2/issue/10006","web":"https://a.hsharp.software/servicedesk/customer/portal/1/SVCZ-3","self":"https://a.hsharp.software/rest/servicedeskapi/request/10006"},"requestType":{"id":"5","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/servicedesk/1/requesttype/5"},"name":"Report a bug","description":"Tell us the problems you're experiencing.","helpText":"","serviceDeskId":"1","groupIds":["1"],"icon":{"id":"10539","_links":{"iconUrls":{"48x48":"https://a.hsharp.software/secure/viewavatar?avatarType=SD_REQTYPE&size=large&avatarId=10539","24x24":"https://a.hsharp.software/secure/viewavatar?avatarType=SD_REQTYPE&size=small&avatarId=10539","16x16":"https://a.hsharp.software/secure/viewavatar?avatarType=SD_REQTYPE&size=xsmall&avatarId=10539","32x32":"https://a.hsharp.software/secure/viewavatar?avatarType=SD_REQTYPE&size=medium&avatarId=10539"}}}},"currentStatus":{"status":"Done","statusDate":{"iso8601":"2017-06-03T16:52:58+0200","jira":"2017-06-03T16:52:58.880+0200","friendly":"Saturday 4:52 PM","epochMillis":1496501578880}}},"customfield_10102":[{"id":"1","name":"Versino CZ","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/organization/1"}}],"labels":[],"customfield_10103":null,"timeestimate":null,"aggregatetimeoriginalestimate":null,"versions":[],"issuelinks":[],"assignee":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"updated":"2017-06-03T16:52:58.000+0200","status":{"self":"https://a.hsharp.software/rest/api/2/status/10002","description":"","iconUrl":"https://a.hsharp.software/","name":"Done","id":"10002","statusCategory":{"self":"https://a.hsharp.software/rest/api/2/statuscategory/3","id":3,"key":"done","colorName":"green","name":"Done"}},"components":[],"timeoriginalestimate":null,"description":"Dobrý den pane Podholo,zasílám výsledky druhého testu. Bylo nutné neprve kompletně odinstalovat a vymazat původní data.Toto se mi podařilo s následujícím výsledkem:1.        Křestní jméno a příjmení u kontaktní osoby - dle ověření funguje oboustraná synchronizace - OK2.        Poznámka u kontaktu - poznámka připojená ke kontaktu se bohužel nedostala do outlooku - CHYBA3.        Více kategorií - kategorie se načítají dle nastavení v SBO - OKProsím tedy o ověření poznámky ke kontaktu.DěkujiS pozdravemPavel Skalický","customfield_10005":"0|i0001b:","customfield_10203":{"id":"1","name":"Time to resolution","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/request/10006/sla/1"},"completedCycles":[{"startTime":{"iso8601":"2017-05-26T16:43:35+0200","jira":"2017-05-26T16:43:35.360+0200","friendly":"26/May/17 4:43 PM","epochMillis":1495809815360},"stopTime":{"iso8601":"2017-06-03T16:52:58+0200","jira":"2017-06-03T16:52:58.880+0200","friendly":"Saturday 4:52 PM","epochMillis":1496501578880},"breached":true,"goalDuration":{"millis":86400000,"friendly":"24h"},"elapsedTime":{"millis":144984640,"friendly":"40h 16m"},"remainingTime":{"millis":-58584640,"friendly":"-16h 16m"}}]},"customfield_10204":{"id":"2","name":"Time to first response","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/request/10006/sla/2"},"completedCycles":[{"startTime":{"iso8601":"2017-05-26T16:43:35+0200","jira":"2017-05-26T16:43:35.360+0200","friendly":"26/May/17 4:43 PM","epochMillis":1495809815360},"stopTime":{"iso8601":"2017-05-26T18:06:58+0200","jira":"2017-05-26T18:06:58.137+0200","friendly":"26/May/17 6:06 PM","epochMillis":1495814818137},"breached":false,"goalDuration":{"millis":28800000,"friendly":"8h"},"elapsedTime":{"millis":984640,"friendly":"16m"},"remainingTime":{"millis":27815360,"friendly":"7h 43m"}}]},"customfield_10205":null,"customfield_10206":null,"customfield_10207":null,"aggregatetimeestimate":null,"summary":"Testování provedných úprav outlook addinu II.","creator":{"self":"https://a.hsharp.software/rest/api/2/user?username=pavel_skalicky%40versino.cz","name":"pavel_skalicky@versino.cz","key":"pavel_skalicky@versino.cz","emailAddress":"pavel_skalicky@versino.cz","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=32"},"displayName":"Pavel Skalický","active":true,"timeZone":"Europe/Prague"},"subtasks":[],"reporter":{"self":"https://a.hsharp.software/rest/api/2/user?username=pavel_skalicky%40versino.cz","name":"pavel_skalicky@versino.cz","key":"pavel_skalicky@versino.cz","emailAddress":"pavel_skalicky@versino.cz","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=32"},"displayName":"Pavel Skalický","active":true,"timeZone":"Europe/Prague"},"customfield_10000":null,"aggregateprogress":{"progress":0,"total":0},"customfield_10200":null,"customfield_10201":null,"customfield_10202":null,"customfield_10004":null,"environment":null,"duedate":null,"progress":{"progress":0,"total":0},"votes":{"self":"https://a.hsharp.software/rest/api/2/issue/SVCZ-3/votes","votes":0,"hasVoted":false}}},{"expand":"operations,versionedRepresentations,editmeta,changelog,renderedFields","id":"10003","self":"https://a.hsharp.software/rest/api/2/issue/10003","key":"SVCZ-2","fields":{"issuetype":{"self":"https://a.hsharp.software/rest/api/2/issuetype/10104","id":"10104","description":"A problem which impairs or prevents the functions of the product.","iconUrl":"https://a.hsharp.software/secure/viewavatar?size=xsmall&avatarId=10303&avatarType=issuetype","name":"Bug","subtask":false,"avatarId":10303},"timespent":null,"project":{"self":"https://a.hsharp.software/rest/api/2/project/10001","id":"10001","key":"SVCZ","name":"Support pro VCZ Outlook Addin SAP B1 Sync","avatarUrls":{"48x48":"https://a.hsharp.software/secure/projectavatar?avatarId=10324","24x24":"https://a.hsharp.software/secure/projectavatar?size=small&avatarId=10324","16x16":"https://a.hsharp.software/secure/projectavatar?size=xsmall&avatarId=10324","32x32":"https://a.hsharp.software/secure/projectavatar?size=medium&avatarId=10324"}},"fixVersions":[],"aggregatetimespent":null,"resolution":{"self":"https://a.hsharp.software/rest/api/2/resolution/10000","id":"10000","description":"Work has been completed on this issue.","name":"Done"},"resolutiondate":"2017-06-03T16:50:57.000+0200","workratio":-1,"lastViewed":"2017-06-03T16:51:09.888+0200","watches":{"self":"https://a.hsharp.software/rest/api/2/issue/SVCZ-2/watchers","watchCount":1,"isWatching":true},"created":"2017-05-19T17:00:26.000+0200","priority":{"self":"https://a.hsharp.software/rest/api/2/priority/3","iconUrl":"https://a.hsharp.software/images/icons/priorities/medium.svg","name":"Medium","id":"3"},"customfield_10100":[],"customfield_10101":{"_links":{"jiraRest":"https://a.hsharp.software/rest/api/2/issue/10003","web":"https://a.hsharp.software/servicedesk/customer/portal/1/SVCZ-2","self":"https://a.hsharp.software/rest/servicedeskapi/request/10003"},"requestType":{"id":"5","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/servicedesk/1/requesttype/5"},"name":"Report a bug","description":"Tell us the problems you're experiencing.","helpText":"","serviceDeskId":"1","groupIds":["1"],"icon":{"id":"10539","_links":{"iconUrls":{"48x48":"https://a.hsharp.software/secure/viewavatar?avatarType=SD_REQTYPE&size=large&avatarId=10539","24x24":"https://a.hsharp.software/secure/viewavatar?avatarType=SD_REQTYPE&size=small&avatarId=10539","16x16":"https://a.hsharp.software/secure/viewavatar?avatarType=SD_REQTYPE&size=xsmall&avatarId=10539","32x32":"https://a.hsharp.software/secure/viewavatar?avatarType=SD_REQTYPE&size=medium&avatarId=10539"}}}},"currentStatus":{"status":"Done","statusDate":{"iso8601":"2017-06-03T16:50:57+0200","jira":"2017-06-03T16:50:57.793+0200","friendly":"Saturday 4:50 PM","epochMillis":1496501457793}}},"customfield_10102":[{"id":"1","name":"Versino CZ","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/organization/1"}}],"labels":[],"customfield_10103":null,"timeestimate":null,"aggregatetimeoriginalestimate":null,"versions":[],"issuelinks":[],"assignee":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"updated":"2017-06-05T09:52:57.000+0200","status":{"self":"https://a.hsharp.software/rest/api/2/status/10002","description":"","iconUrl":"https://a.hsharp.software/","name":"Done","id":"10002","statusCategory":{"self":"https://a.hsharp.software/rest/api/2/statuscategory/3","id":3,"key":"done","colorName":"green","name":"Done"}},"components":[],"timeoriginalestimate":null,"description":"Dobrý den pane Podholo,\r\n\r\npustil jsem se do testování addinu s požadovanými úpravami. \r\n\r\nPro jistotu jsem odstranil své původní nastavení a naistaloval a nastavil addin znovu.Poté mi proběhla úvodní synchronizace, která vypadá spíše vpořádku (až na drobnost níže, které jsem si všimnul). \r\n\r\nBohužel dále mi neprobíhají průběžné aktualizace kontaktů. Když je spustím cyklus probíhá, ale patrně nedokončí. Úkoly a schůzky doběhnou.\r\n\r\n2017-05-19_1617.png\r\n2017-05-19_1617_001.png\r\n\r\nV monitoringu B1i serveru jsem si nevšimnul žádné nesrovnalosti. V příloze přikládám logy pro ověření.\r\n\r\nU jednoho kontaktu se nedoplnila výchozí kategorie \"SAP B1\"\r\n\r\n2017-05-19_1620.png\r\n\r\nTím, že neprobíhá průběžná aktualizace kontaktů, nelze bohužel dále testovat připravené úpravy.\r\n\r\nNepodařilo se mi též nahrát nový kontakt z outlooku do SBO - viz přiložený obrázek\r\n\r\n2017-05-19_1640.png\r\n\r\nPro jistotu jsem vyzkoušel celé nastavení znovu (výmaz původních dat, výmaz nastavení => nové nastavení)\r\n\r\nBohužel po této akci se kontakty vůbec nesynchronizují, neprojde ani úvodní synchronizace.\r\n\r\nLogy z druhého běhu též přikládám.\r\n\r\nMohl byste toto prosím ověřit.\r\n\r\nDíky\r\nS pozdravem\r\n\r\nPavel Skalický","customfield_10005":"0|i0000n:","customfield_10203":{"id":"1","name":"Time to resolution","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/request/10003/sla/1"},"completedCycles":[{"startTime":{"iso8601":"2017-05-19T17:00:28+0200","jira":"2017-05-19T17:00:28.076+0200","friendly":"19/May/17 5:00 PM","epochMillis":1495206028076},"stopTime":{"iso8601":"2017-06-03T16:50:57+0200","jira":"2017-06-03T16:50:57.793+0200","friendly":"Saturday 4:50 PM","epochMillis":1496501457793},"breached":true,"goalDuration":{"millis":86400000,"friendly":"24h"},"elapsedTime":{"millis":288000000,"friendly":"80h"},"remainingTime":{"millis":-201600000,"friendly":"-56h"}}]},"customfield_10204":{"id":"2","name":"Time to first response","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/request/10003/sla/2"},"completedCycles":[{"startTime":{"iso8601":"2017-05-19T17:00:28+0200","jira":"2017-05-19T17:00:28.076+0200","friendly":"19/May/17 5:00 PM","epochMillis":1495206028076},"stopTime":{"iso8601":"2017-05-22T06:18:19+0200","jira":"2017-05-22T06:18:19.637+0200","friendly":"22/May/17 6:18 AM","epochMillis":1495426699637},"breached":false,"goalDuration":{"millis":28800000,"friendly":"8h"},"elapsedTime":{"millis":0,"friendly":"0m"},"remainingTime":{"millis":28800000,"friendly":"8h"}}]},"customfield_10205":null,"customfield_10206":null,"customfield_10207":null,"aggregatetimeestimate":null,"summary":"Testování provedných úprav outlook addinu","creator":{"self":"https://a.hsharp.software/rest/api/2/user?username=pavel_skalicky%40versino.cz","name":"pavel_skalicky@versino.cz","key":"pavel_skalicky@versino.cz","emailAddress":"pavel_skalicky@versino.cz","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=32"},"displayName":"Pavel Skalický","active":true,"timeZone":"Europe/Prague"},"subtasks":[],"reporter":{"self":"https://a.hsharp.software/rest/api/2/user?username=pavel_skalicky%40versino.cz","name":"pavel_skalicky@versino.cz","key":"pavel_skalicky@versino.cz","emailAddress":"pavel_skalicky@versino.cz","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bd9c70edabecc86a47d1fad60ba77e72?d=mm&s=32"},"displayName":"Pavel Skalický","active":true,"timeZone":"Europe/Prague"},"customfield_10000":null,"aggregateprogress":{"progress":0,"total":0},"customfield_10200":"com.atlassian.servicedesk.internal.api.customfields.feedback.RequestFeedbackCFValue@d39cb","customfield_10201":"2017-06-05T09:52:57.000+0200","customfield_10202":null,"customfield_10004":null,"environment":null,"duedate":null,"progress":{"progress":0,"total":0},"votes":{"self":"https://a.hsharp.software/rest/api/2/issue/SVCZ-2/votes","votes":0,"hasVoted":false}}},{"expand":"operations,versionedRepresentations,editmeta,changelog,renderedFields","id":"10005","self":"https://a.hsharp.software/rest/api/2/issue/10005","key":"SKB-3","fields":{"issuetype":{"self":"https://a.hsharp.software/rest/api/2/issuetype/10104","id":"10104","description":"A problem which impairs or prevents the functions of the product.","iconUrl":"https://a.hsharp.software/secure/viewavatar?size=xsmall&avatarId=10303&avatarType=issuetype","name":"Bug","subtask":false,"avatarId":10303},"timespent":null,"project":{"self":"https://a.hsharp.software/rest/api/2/project/10002","id":"10002","key":"SKB","name":"KnowledgeBase Support","avatarUrls":{"48x48":"https://a.hsharp.software/secure/projectavatar?avatarId=10324","24x24":"https://a.hsharp.software/secure/projectavatar?size=small&avatarId=10324","16x16":"https://a.hsharp.software/secure/projectavatar?size=xsmall&avatarId=10324","32x32":"https://a.hsharp.software/secure/projectavatar?size=medium&avatarId=10324"}},"fixVersions":[],"aggregatetimespent":null,"resolution":null,"resolutiondate":null,"workratio":-1,"lastViewed":"2017-06-03T16:53:26.166+0200","watches":{"self":"https://a.hsharp.software/rest/api/2/issue/SKB-3/watchers","watchCount":1,"isWatching":true},"created":"2017-05-26T05:14:10.000+0200","priority":{"self":"https://a.hsharp.software/rest/api/2/priority/3","iconUrl":"https://a.hsharp.software/images/icons/priorities/medium.svg","name":"Medium","id":"3"},"customfield_10100":[],"customfield_10101":null,"customfield_10102":[],"labels":[],"customfield_10103":null,"timeestimate":null,"aggregatetimeoriginalestimate":null,"versions":[],"issuelinks":[],"assignee":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"updated":"2017-05-26T06:02:29.000+0200","status":{"self":"https://a.hsharp.software/rest/api/2/status/10009","description":"This was auto-generated by JIRA Service Desk during workflow import","iconUrl":"https://a.hsharp.software/images/icons/status_generic.gif","name":"Work in progress","id":"10009","statusCategory":{"self":"https://a.hsharp.software/rest/api/2/statuscategory/4","id":4,"key":"indeterminate","colorName":"yellow","name":"In Progress"}},"components":[],"timeoriginalestimate":null,"description":null,"customfield_10005":"0|i00013:","customfield_10203":{"id":"3","name":"Time to resolution","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/request/10005/sla/3"},"completedCycles":[],"ongoingCycle":{"startTime":{"iso8601":"2017-05-26T05:14:10+0200","jira":"2017-05-26T05:14:10.643+0200","friendly":"26/May/17 5:14 AM","epochMillis":1495768450643},"breachTime":{"iso8601":"2017-05-31T09:00:00+0200","jira":"2017-05-31T09:00:00.000+0200","friendly":"31/May/17 9:00 AM","epochMillis":1496214000000},"breached":true,"paused":false,"withinCalendarHours":false,"goalDuration":{"millis":86400000,"friendly":"24h"},"elapsedTime":{"millis":288000000,"friendly":"80h"},"remainingTime":{"millis":-201600000,"friendly":"-56h"}}},"customfield_10204":{"id":"4","name":"Time to first response","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/request/10005/sla/4"},"completedCycles":[{"startTime":{"iso8601":"2017-05-26T05:14:10+0200","jira":"2017-05-26T05:14:10.643+0200","friendly":"26/May/17 5:14 AM","epochMillis":1495768450643},"stopTime":{"iso8601":"2017-05-26T05:58:26+0200","jira":"2017-05-26T05:58:26.057+0200","friendly":"26/May/17 5:58 AM","epochMillis":1495771106057},"breached":false,"goalDuration":{"millis":28800000,"friendly":"8h"},"elapsedTime":{"millis":0,"friendly":"0m"},"remainingTime":{"millis":28800000,"friendly":"8h"}}]},"customfield_10205":null,"customfield_10206":null,"customfield_10207":null,"aggregatetimeestimate":null,"summary":"AIRDUC + Fatra, najde mi to úplně všechno","creator":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"subtasks":[],"reporter":{"self":"https://a.hsharp.software/rest/api/2/user?username=vacenovska.tereza%40gumex.cz","name":"vacenovska.tereza@gumex.cz","key":"vacenovska.tereza@gumex.cz","emailAddress":"vacenovska.tereza@gumex.cz","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/500ffc133a2d12dc91265174c8db9a24?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/500ffc133a2d12dc91265174c8db9a24?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/500ffc133a2d12dc91265174c8db9a24?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/500ffc133a2d12dc91265174c8db9a24?d=mm&s=32"},"displayName":"Tereza Vacenovská","active":true,"timeZone":"Europe/Prague"},"customfield_10000":null,"aggregateprogress":{"progress":0,"total":0},"customfield_10200":null,"customfield_10201":null,"customfield_10202":null,"customfield_10004":null,"environment":null,"duedate":null,"progress":{"progress":0,"total":0},"votes":{"self":"https://a.hsharp.software/rest/api/2/issue/SKB-3/votes","votes":0,"hasVoted":false}}},{"expand":"operations,versionedRepresentations,editmeta,changelog,renderedFields","id":"10004","self":"https://a.hsharp.software/rest/api/2/issue/10004","key":"SKB-2","fields":{"issuetype":{"self":"https://a.hsharp.software/rest/api/2/issuetype/10104","id":"10104","description":"A problem which impairs or prevents the functions of the product.","iconUrl":"https://a.hsharp.software/secure/viewavatar?size=xsmall&avatarId=10303&avatarType=issuetype","name":"Bug","subtask":false,"avatarId":10303},"timespent":null,"project":{"self":"https://a.hsharp.software/rest/api/2/project/10002","id":"10002","key":"SKB","name":"KnowledgeBase Support","avatarUrls":{"48x48":"https://a.hsharp.software/secure/projectavatar?avatarId=10324","24x24":"https://a.hsharp.software/secure/projectavatar?size=small&avatarId=10324","16x16":"https://a.hsharp.software/secure/projectavatar?size=xsmall&avatarId=10324","32x32":"https://a.hsharp.software/secure/projectavatar?size=medium&avatarId=10324"}},"fixVersions":[],"aggregatetimespent":null,"resolution":null,"resolutiondate":null,"workratio":-1,"lastViewed":"2017-05-26T06:02:48.403+0200","watches":{"self":"https://a.hsharp.software/rest/api/2/issue/SKB-2/watchers","watchCount":1,"isWatching":true},"created":"2017-05-26T05:13:57.000+0200","priority":{"self":"https://a.hsharp.software/rest/api/2/priority/3","iconUrl":"https://a.hsharp.software/images/icons/priorities/medium.svg","name":"Medium","id":"3"},"customfield_10100":[],"customfield_10101":null,"customfield_10102":[],"labels":[],"customfield_10103":null,"timeestimate":null,"aggregatetimeoriginalestimate":null,"versions":[],"issuelinks":[],"assignee":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"updated":"2017-05-26T06:02:47.000+0200","status":{"self":"https://a.hsharp.software/rest/api/2/status/10009","description":"This was auto-generated by JIRA Service Desk during workflow import","iconUrl":"https://a.hsharp.software/images/icons/status_generic.gif","name":"Work in progress","id":"10009","statusCategory":{"self":"https://a.hsharp.software/rest/api/2/statuscategory/4","id":4,"key":"indeterminate","colorName":"yellow","name":"In Progress"}},"components":[],"timeoriginalestimate":null,"description":"Zdá se, že se nám nepropisují hodnocení v případě Výsledků hledání na úvodní straně. Ale přitom ve Správě komentářů toto hodnocení vidět jde (2. screenshot).\r\n\r\nTaké je zajímavé, že ve Správě komentářů, když zadám kód produktu a jinak všechno nechám stejné. Také mi to již Použití produktu nezobrazí. (3. screenshot).","customfield_10005":"0|i0000v:","customfield_10203":{"id":"3","name":"Time to resolution","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/request/10004/sla/3"},"completedCycles":[],"ongoingCycle":{"startTime":{"iso8601":"2017-05-26T05:13:58+0200","jira":"2017-05-26T05:13:58.074+0200","friendly":"26/May/17 5:13 AM","epochMillis":1495768438074},"breachTime":{"iso8601":"2017-05-31T09:00:00+0200","jira":"2017-05-31T09:00:00.000+0200","friendly":"31/May/17 9:00 AM","epochMillis":1496214000000},"breached":true,"paused":false,"withinCalendarHours":false,"goalDuration":{"millis":86400000,"friendly":"24h"},"elapsedTime":{"millis":288000000,"friendly":"80h"},"remainingTime":{"millis":-201600000,"friendly":"-56h"}}},"customfield_10204":{"id":"4","name":"Time to first response","_links":{"self":"https://a.hsharp.software/rest/servicedeskapi/request/10004/sla/4"},"completedCycles":[{"startTime":{"iso8601":"2017-05-26T05:13:58+0200","jira":"2017-05-26T05:13:58.074+0200","friendly":"26/May/17 5:13 AM","epochMillis":1495768438074},"stopTime":{"iso8601":"2017-05-26T05:56:56+0200","jira":"2017-05-26T05:56:56.712+0200","friendly":"26/May/17 5:56 AM","epochMillis":1495771016712},"breached":false,"goalDuration":{"millis":28800000,"friendly":"8h"},"elapsedTime":{"millis":0,"friendly":"0m"},"remainingTime":{"millis":28800000,"friendly":"8h"}}]},"customfield_10205":null,"customfield_10206":null,"customfield_10207":null,"aggregatetimeestimate":null,"summary":"nepropisují hodnocení v případě Výsledků hledání na úvodní straně","creator":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"subtasks":[],"reporter":{"self":"https://a.hsharp.software/rest/api/2/user?username=vacenovska.tereza%40gumex.cz","name":"vacenovska.tereza@gumex.cz","key":"vacenovska.tereza@gumex.cz","emailAddress":"vacenovska.tereza@gumex.cz","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/500ffc133a2d12dc91265174c8db9a24?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/500ffc133a2d12dc91265174c8db9a24?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/500ffc133a2d12dc91265174c8db9a24?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/500ffc133a2d12dc91265174c8db9a24?d=mm&s=32"},"displayName":"Tereza Vacenovská","active":true,"timeZone":"Europe/Prague"},"customfield_10000":null,"aggregateprogress":{"progress":0,"total":0},"customfield_10200":null,"customfield_10201":null,"customfield_10202":null,"customfield_10004":null,"environment":null,"duedate":null,"progress":{"progress":0,"total":0},"votes":{"self":"https://a.hsharp.software/rest/api/2/issue/SKB-2/votes","votes":0,"hasVoted":false}}},{"expand":"operations,versionedRepresentations,editmeta,changelog,renderedFields","id":"10100","self":"https://a.hsharp.software/rest/api/2/issue/10100","key":"DSAPB1O-1","fields":{"issuetype":{"self":"https://a.hsharp.software/rest/api/2/issuetype/10100","id":"10100","description":"An improvement or enhancement to an existing feature or task.","iconUrl":"https://a.hsharp.software/secure/viewavatar?size=xsmall&avatarId=10310&avatarType=issuetype","name":"Improvement","subtask":false,"avatarId":10310},"timespent":null,"project":{"self":"https://a.hsharp.software/rest/api/2/project/10101","id":"10101","key":"DSAPB1O","name":"VCZ Outlook Addin SAP B1 Sync","avatarUrls":{"48x48":"https://a.hsharp.software/secure/projectavatar?avatarId=10324","24x24":"https://a.hsharp.software/secure/projectavatar?size=small&avatarId=10324","16x16":"https://a.hsharp.software/secure/projectavatar?size=xsmall&avatarId=10324","32x32":"https://a.hsharp.software/secure/projectavatar?size=medium&avatarId=10324"}},"fixVersions":[],"aggregatetimespent":null,"resolution":null,"resolutiondate":null,"workratio":-1,"lastViewed":"2017-06-08T06:03:39.877+0200","watches":{"self":"https://a.hsharp.software/rest/api/2/issue/DSAPB1O-1/watchers","watchCount":1,"isWatching":true},"created":"2017-06-07T14:47:08.000+0200","priority":{"self":"https://a.hsharp.software/rest/api/2/priority/3","iconUrl":"https://a.hsharp.software/images/icons/priorities/medium.svg","name":"Medium","id":"3"},"customfield_10100":[],"customfield_10101":null,"customfield_10102":null,"labels":[],"customfield_10103":null,"timeestimate":null,"aggregatetimeoriginalestimate":null,"versions":[],"issuelinks":[],"assignee":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"updated":"2017-06-08T06:03:35.000+0200","status":{"self":"https://a.hsharp.software/rest/api/2/status/10000","description":"","iconUrl":"https://a.hsharp.software/","name":"To Do","id":"10000","statusCategory":{"self":"https://a.hsharp.software/rest/api/2/statuscategory/2","id":2,"key":"new","colorName":"blue-gray","name":"To Do"}},"components":[],"timeoriginalestimate":null,"description":null,"customfield_10005":"0|i0001j:","customfield_10203":null,"customfield_10204":null,"customfield_10205":null,"customfield_10206":null,"customfield_10207":null,"aggregatetimeestimate":null,"summary":"Local database upgrade","creator":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"subtasks":[],"reporter":{"self":"https://a.hsharp.software/rest/api/2/user?username=davidpodhola","name":"davidpodhola","key":"davidpodhola","emailAddress":"david.podhola@hsharp.software","avatarUrls":{"48x48":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=48","24x24":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=24","16x16":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=16","32x32":"https://secure.gravatar.com/avatar/bc692ef2fe40956eedd6abca0de16352?d=mm&s=32"},"displayName":"David Podhola","active":true,"timeZone":"Europe/Prague"},"customfield_10000":null,"aggregateprogress":{"progress":0,"total":0},"customfield_10200":null,"customfield_10201":null,"customfield_10202":null,"customfield_10004":null,"environment":null,"duedate":null,"progress":{"progress":0,"total":0},"votes":{"self":"https://a.hsharp.software/rest/api/2/issue/DSAPB1O-1/votes","votes":0,"hasVoted":false}}}]} """>

        type Issue = {
            Key : string
            Summary : string
        }

    module Outlook =
        type OutlookTask = {
            Key : string
            Subject : string
        }