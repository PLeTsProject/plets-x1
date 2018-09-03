# Welcome to plets-x1 repository.

## What is plets?
PLeTs (sometimes written as *plets*) is a product line of testing tools. Products from plets are able to generate testing script several testing tools. All necessary data is extracted from system's models.

## What is *plets-x1* and why there are many plets?

We are currrently aware of 3 projects involving plets.

- [LESSE's plets project](https://github.com/GiliSchmidt/PleTs-Testing). This project is under development by LESSE lab at UNIPAMPA. This version of plets is built over .NET Framework 4.5 and is made to run on Windows systems.
- [Plets-v](https://github.com/AndersonDomingues/plets-v). This is an experimental project and presents a new organisation and corrections to architectural flaws of previous version. Also, this version is built over Dotnet Core 2.2, which target Windows, Linux and MacOS systems.
- [Plets-x1](https://github.com/AndersonDomingues/plets-x1). This is an experimental project. Why do we need to correct flaws when we can blow everything up and build from scratch? This version of plets is the result of lone effort for creating a new plets experience. However, there's no free lunch, and we pay the price of having a nice and flawless project by taking more time to deliver results when comparing to previous projets. This version is also built over Dotnet Core 2.2 and targets multiple operating systems as well.

## How is this project files organized?

We organized the project in the following folders. 

- *Docs*: Self-explanatorie, we store some useful documentation here.
- *Products*: Scripts for build many products of PLeTs. Since there are many possible products, only a few scripts are available so that you can use them as examples to build your own products.
- *Tools*: Some scripts and goodies that makes your life easier.
- *Src*: Source code of the project. You will see three other folders inside src because plets-x1 have three kind of components. We explain them below.

## What is the difference between blocks, core and shared components?

We have three different components in this project.
- *Blocks*: Parts of products that have some specific function as, for example, parsing some kind of file.
- *Core*: Data structures that blocks use when communicating with each other. 
- *Shared*: Pieces of software that can be used by several blocks. An example could be a library to handle some kind of file.

The following picture illustrate the relation between these three kind of components.

![Relation between types of components.](https://raw.githubusercontent.com/andersondomingues/plets-x1/master/Docs/plets-x1%20-%20core%2C%20shared%20and%20blocks.png)

For now, we aim to provide the following blocks (in yellow) and core structures (in orange).

![Block and core structures.](https://raw.githubusercontent.com/andersondomingues/plets-x1/master/Docs/Plets-x1-level2-diagram.png)

No shared lib is being used, but we intend to do so in a near future.

## How to clone this repo

First, you need to clone this repo by entering the following command.

`git clone https://github.com/PLeTsProject/plets-x1.git --recurse-submodules`

Please be aware that the you will be also cloning submodules' code and the operation may take a while. Each submodule has its own repository and pull requests should address them.