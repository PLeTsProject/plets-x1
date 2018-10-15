# Welcome to plets-x1 repository.

## What is plets?
PLeTs (sometimes written as *plets*) is a product line of software testing tools for model-based testing. Products from plets are capable of generating testing scripts for using with several testing tools, including on-the-shelf and free open-source solutions. 

Most of products generate extended formal models (e.g. finite state machines) from system models (e.g. UML diagrams). Then, a sequence generation method is applied to the generated formal model. The output of sequence generation methods is a set of test cases ready to be converted to technology-specific scripts. The whole process is fully automated by plets products.

## Project status

Plets is not a tool, but a family of tools. In the past, some of these tools were succeffully adopted in industrial context and proven to reduce effort when designing test suites for web applications []. Tools for other domains were also provided [][]. The goal of this project is to provide a configurable architecture that offers the benefits from all previous deployed tools while allowing new tools to be easily designed.

However, there's no free lunch, and we pay the price of having a nice and flawless project by taking more time to deliver results when comparing to previous projets involving plets. Although we are currently working on the project, there is no fixed time to deliver any update. However, feel free to contact us regarding the project, since we write e-mails faster than we write code (to be verified). 

Plets-x1 is built over Dotnet Core 2.1 and targets multiple operating systems. 

## How is this project organized?

We organized the project source-code in a few folder. 

- *Build*: folder to where compiled products are deployed.
- *Docs*: Self-explanatorie, we store some useful documentation here. For now, we have only a few pictures, but it tends to change in a near future.
- *Plets-x1*: Source code of the project. You will see a couple folders inside `/plets-x1`. We explain them in the next section.
- *Products*: Recipies for build the many products of PLeTs. Since there are many possible products, only a few recipies are provided. Take them as example so that you can build your own products (or ask us to do so).
- *Tools*: Some scripts and goodies.

## An overview on the architecture

We have three different components in this project.
- *Functional Components (FCs)* - `plets-x1/blocks`: Parts of products that have some specific function as, for example, parsing some kind of file.
- *Data Structures (DSs)* - `plets-x1/core`: Data structures that functional components use when communicating to each other. 
- *Shared Libraries (SLs)* - `plets-x1/shared`: Pieces of software that can be used into several blocks. An example could be a library to handle some kind of file.

The following picture illustrate the relation between FCs (blocks), DSs (core) and SLs (shared libs.).

![Relation between types of components.](https://raw.githubusercontent.com/Plets-x1/plets-x1/master/Docs/plets-x1%20-%20core%2C%20shared%20and%20blocks.png)

For now, we aim to provide the following FCs (in yellow) and DSs (in orange). Please note that no shared lib is being used, but we intend to do so soon.

![Block and core structures.](https://raw.githubusercontent.com/PLets-x1/plets-x1/master/Docs/Plets-x1-level2-diagram.png)

