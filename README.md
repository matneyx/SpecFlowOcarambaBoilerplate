SpecFlow / Ocaramba / NUnit / Autofac Boilerplate
================================================

What?
-----

This is a .Net / Visual Studio project intended to get you up and running with
Selenium WebDriver End-To-End (E2E) tests without the hassle of getting all the
components working together.

It leverages [SpecFlow](SpecFlow),
[Ocaramba](https://github.com/ObjectivityLtd/Ocaramba), and
[NUnit](https://nunit.org/) for easy [Behavior Driven Development
(BDD)](https://cucumber.io/docs/Behavior%20Driven%20Development%20(BDD))
testing, and [Autofac](https://autofac.org/) for IoC / Dependency Injection.

Who?
----

This is intended for software developers who want to write automated E2E tests,
as well as software testers who are interested in trying their hand at test
automation.

Why?
----

At my work, I had to spin up a new integration test project that worked entirely
within Visual Studio, and it took me much longer than I’d expected. That kind of
setup could dissuade testers from testing, and I didn’t want that to happen.

How?
----

### Extensions

For best results, I recommend the following VS plugins:

-   SpecFlow

    -   [For Visual Studio
        2015](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2015)

    -   [For Visual Studio
        2017](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2017)

    -   [For Visual Studio
        2019](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio)

-   [NUnit3 Test
    Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter)

### Installation

The easiest way to install this is to download the zipped up version and drop it
in your existing repo.

If you want your integration tests to be its own repository, do the following:

`git clone –depth 1 https://github.com/matneyx/SpecFlowOcarambaBoilerplate.git
<YourRepoName>`

Then delete the `.git `folder within the new `SpecFlowOcarambaBoilerplate`
folder.

Once you’ve done that, rename all instances of `SpecFlowOcarambaBoilerplate with
whatever you’ve named your repo (I’d just do a Find and Replace inside Visual
Studio Code), as well as renaming the folder and solution / project.  Test to
make sure the demo test runs, and make corrections where necessary.`

`Finally, git init and link the new remote to wherever you want it.`

### Where to start?

Build the project. You may have to do some nuget finagling for it to build, but
everything is available in the default nuget source.

Open your Test Explorer and you should see the ICanSearchForThings test. Run
that – it should open a new window, go to Google, search for Wikipedia, and then
close.

If all of that works, you’re ready to build your first test.

### Building your own tests

TODO
