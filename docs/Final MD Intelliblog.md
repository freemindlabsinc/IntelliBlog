Final MD Intelliblog

# Building IntelliBlog: A Journey into AI-Assisted Content Creation

## Introduction

Welcome to the first post of the IntelliBlog journey! In this series, I'll be sharing our experience of creating an AI-assisted content creation tool from the ground up. As someone new to UI design but passionate about the potential of AI, I hope my journey will inspire and inform others venturing into similar territories.

![A collage of various user interfaces from popular research and AI tools](path/to/ui-collage-image.jpg)

## The Genesis of IntelliBlog

For the creation of IntelliBlog, I took on the responsibility of creating the user interface. I've never done anything like this before, although like all of us, I've used countless interfaces. I've been diving headfirst into different research tools and AI applications that all use slightly different visual metaphors to connect people to their information and its transformations.

My hope is that I can relate the experience I've had building this interface and describe what we are planning to do with it. It's funny, we are using this text as an example in the application, and I feel like I am on the other side of the fourth wall with you! Let's dive in!

We started with a promising idea last year of creating a tool that is now becoming a native feature in the Google stack. (I'm in a beta that exposes a video transcript interactive AI chatbot right in YouTube, which allows questioning video transcripts directly, as well as summarizing and outlining content.) We thoroughly investigated this capability early on but realized it would probably become a feature in YouTube... and here it comes.

Our focus shifted to a way to *collect, manage*, and *generate* responses to **all media**. We're now building a path to publishing effective, well-researched posts, using AI for drafts. Well-prompted LLMs can provide solid and rapid framing of information, which users can readily modify and finalize. Our intention is to leverage the most mature capabilities while avoiding the pitfalls of hallucination.

## Designing the User Interface

In our application, we're giving users access to summation and creation capabilities, and an orchestrated source management capability, and have plans to continually grow strong validation features by helping users easily access and integrate high-reputation sources. 

> "We are focusing on leaving the human mind in control, and leveraging AI to help orchestrate and build content."

We hope to expand beyond simple blog posts, creating a space where a post becomes a universal broadcast position for any specific social media platform. Ultimately, we envision a tool with which one can personally organize and curate interesting, well-expressed, and well-backed information. By curating sources, reviewing and understanding a range of information about a topic, and synthesizing those ideas after thoughtful investigation, users can generate great posts.

I hope that walking you through the actual building of the interface will reflect some of these intentions.

### Choosing Our Tools

We used some standard tools (Draw.io is my design tool) to build out the mocks for implementing the bootstrap framework. Trying to get smart about interface subcomponents and determining the best use for each in our transformative vision was, to say the least, challenging.

But as you can see, the tool is working :D  and uses many of the standard metaphors of modern applications. Rendering these posts in Markdown and giving users easy access to a thoughtful composition UI is critical to us, and we will keep that in focus for the final user release.

![A screenshot of your interface mock-up created in Draw.io](path/to/drawio-mockup.jpg)

### Challenges and Learning Curves

The other great challenge I face is understanding how to integrate the backend with what happens in the interface.

I understood going in that a web page is essentially a frame for the data that lives in data structures on the backend, and that the interface allows transformation of this data. But my understanding of things like GraphQL and how you can leverage that intuitive metaphor to access the data elements in a backend structure—and how we can automate presenting them through technologies like Hot Chocolate and Raspberry Cake Pop to generate the required code—has been eye-opening.  Coming from a Military Signal / IT Ops background (where I had to fix/design many systems) this is as high-speed and low-drag as it gets.

> "It is a fundamental change from making tools, to making tools with parts that are language-aware."

I now think things like "How can I access and create, slice and dice, innovate to generate, from the array on the buffet? These are the thoughts that keep me excited!

## The Vision for IntelliBlog

We will integrate Semantic Kernel in our tech stack along with C# and  powerful Python tools for RAG... SLMs... offline capabilities... but wait, I'm getting way ahead of myself here—this is just the first simple display of the working product, without all that juicy stuff inside it... yet! :)

We are building a tool that could potentially scale to a billion beautiful baby blogs. Who knows? I'm smiling, but it isn't beyond imagining.

### Key Future Features:
- AI-assisted drafting
- Source validation
- Multi-platform publishing

![A simple infographic showing the planned features of your tool](path/to/feature-infographic.jpg)

## Looking Ahead

Like any other small software house, we are dreaming big about the future and expanding the capabilities of our tool. We will grow our community and use feedback and tenacity to turn personal notions and interests into high-quality expression.

## Conclusion

As we continue to develop IntelliBlog, I am excited to share our progress while creating a tool that streamlines content composition. In the next post, I'll be revealing some of our initial sketches and diving deeper into how AI is reshaping the way we think about content creation. Stay tuned, and feel free to share your thoughts or questions in the comments below!