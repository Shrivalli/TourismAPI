// ActionProvider.js

// Define a common loading response
const loadingResponse = {
  text: '...',
  isUserMessage: false,
}

const provideAction = (parsedMessage, setMessages) => {
  switch (parsedMessage.type) {
    case 'BEST_SPOTS':
      // Show loading state before displaying the bot's response
      setMessages((prevMessages) => [...prevMessages, loadingResponse])

      // Simulate delay for loading state (you can adjust the time as needed)
      const loadingDelay = 1000 // 1 second
      setTimeout(() => {
        // Here, you can fetch the actual best spots information from an API or a data source
        const bestSpotsResponse = {
          text: 'Sure! Here are some of the best spots in Kerala: Spot 1, Spot 2, Spot 3, etc.',
          isUserMessage: false,
        }
        setMessages((prevMessages) => [
          ...prevMessages.slice(0, -1),
          bestSpotsResponse,
        ])
      }, loadingDelay)
      break
    case 'ANOTHER_ACTION':
      // For other actions, you can show the same common loading state
      setMessages((prevMessages) => [...prevMessages, loadingResponse])

      // Simulate delay for loading state for another action (you can adjust the time as needed)
      const anotherLoadingDelay = 2000 // 2 seconds
      setTimeout(() => {
        // Here, you can fetch the actual data for the another action from an API or a data source
        const actualResponse = {
          text: 'Here is the response for another action.',
          isUserMessage: false,
        }
        setMessages((prevMessages) => [
          ...prevMessages.slice(0, -1),
          actualResponse,
        ])
      }, anotherLoadingDelay)
      break
    case 'UNKNOWN':
      // Add a default response for unknown queries
      const unknownResponse = {
        text: "I'm sorry, I couldn't understand your query.",
        isUserMessage: false,
      }
      setMessages((prevMessages) => [...prevMessages, unknownResponse])
      break
    default:
      break
  }
}

export default provideAction
