import React, { useState, useEffect, useRef } from 'react'
import ChatBot from '../ChatBot/ChatBot'
import hill1 from '../../assets/images/hill1.png'
import hill2 from '../../assets/images/hill2.png'
import hill3 from '../../assets/images/hill3.png'
import hill4 from '../../assets/images/hill4.png'
import hill5 from '../../assets/images/hill5.png'
import leaf from '../../assets/images/leaf.png'
import tree from '../../assets/images/tree.png'
import plant from '../../assets/images/plant.png'
import chatbot from '../../assets/images/chatbot.jpg'
import './HomePage.css'
const HomePage = () => {
  let text = document.getElementById('destinationtext')
  let leafval = document.getElementById('leaf')
  let hill1st = document.getElementById('hill-1')
  let hill4th = document.getElementById('hill-4')
  let hill5th = document.getElementById('hill-5')

  window.addEventListener('scroll', () => {
    let value = window.scrollY
    if (text) {
      text.style.marginTop = value * 1.5 + 'px'
    }
    if (leafval) {
      leafval.style.top = value * -1.5 + 'px'
      leafval.style.left = value * -1.5 + 'px'
    }
    if (hill5th) {
      hill5th.style.left = value * 1.5 + 'px'
    }
    if (hill4th) {
      hill4th.style.left = value * -1.5 + 'px'
    }
    if (hill1st) {
      hill1st.style.top = value * 0.1 + 'px'
    }
  })
  const [isChatBotVisible, setChatBotVisibility] = useState(false)
  const chatbotRef = useRef(null)

  const handleImageClick = () => {
    // Show the chatbot when the image is clicked
    setChatBotVisibility(true)
  }

  const handleClickOutsideChatbot = (event) => {
    // Check if the clicked element is outside the chatbot area
    if (chatbotRef.current && !chatbotRef.current.contains(event.target)) {
      setChatBotVisibility(false) // Close the chatbot
    }
  }

  useEffect(() => {
    // Add event listener to detect clicks outside the chatbot area
    document.addEventListener('click', handleClickOutsideChatbot)

    return () => {
      // Remove the event listener when the component is unmounted
      document.removeEventListener('click', handleClickOutsideChatbot)
    }
  }, [])
  return (
    <div className="homePage">
      <section className="homecontainer">
        <img className="homeimg" src={hill1} id="hill-1" alt="hill-1" />
        <img className="homeimg" src={hill2} id="hill-2" alt="hill-2" />
        <img className="homeimg" src={hill3} id="hill-3" alt="hill-3" />
        <img className="homeimg" src={hill4} id="hill-4" alt="hill-4" />
        <img className="homeimg" src={hill5} id="hill-5" alt="hill-5" />
        <img className="homeimg" src={tree} id="tree" alt="tree" />
        <h2 id="destinationtext">Choose your Destination</h2>
        <img className="homeimg" src={leaf} id="leaf" alt="tree" />
        <img className="homeimg" src={plant} id="plant" alt="plant" />
      </section>
      <section className="homecontainer2">
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum
          nihil ut perferendis ea et natus quod debitis atque, voluptate soluta
          porro ipsam, impedit odio veritatis incidunt reprehenderit numquam
          cumque. Repudiandae!
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum
          nihil ut perferendis ea et natus quod debitis atque, voluptate soluta
          porro ipsam, impedit odio veritatis incidunt reprehenderit numquam
          cumque. Repudiandae!
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum
          nihil ut perferendis ea et natus quod debitis atque, voluptate soluta
          porro ipsam, impedit odio veritatis incidunt reprehenderit numquam
          cumque. Repudiandae!
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum
          nihil ut perferendis ea et natus quod debitis atque, voluptate soluta
          porro ipsam, impedit odio veritatis incidunt reprehenderit numquam
          cumque. Repudiandae!
        </p>

        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum
          nihil ut perferendis ea et natus quod debitis atque, voluptate soluta
          porro ipsam, impedit odio veritatis incidunt reprehenderit numquam
          cumque. Repudiandae!
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum
          nihil ut perferendis ea et natus quod debitis atque, voluptate soluta
          porro ipsam, impedit odio veritatis incidunt reprehenderit numquam
          cumque. Repudiandae!
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum
          nihil ut perferendis ea et natus quod debitis atque, voluptate soluta
          porro ipsam, impedit odio veritatis incidunt reprehenderit numquam
          cumque. Repudiandae!
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum
          nihil ut perferendis ea et natus quod debitis atque, voluptate soluta
          porro ipsam, impedit odio veritatis incidunt reprehenderit numquam
          cumque. Repudiandae!
        </p>
      </section>
      <div className="chatbotClickBtnDiv" ref={chatbotRef}>
        <img
          className="chatbotClickBtn"
          src={chatbot}
          alt="Click Me"
          onClick={handleImageClick}
        />
        {isChatBotVisible && <ChatBot />}
      </div>
    </div>
  )
}

export default HomePage
