// MessageParser.js
const parseMessage = (userInput) => {
  const lowerCaseInput = userInput.toLowerCase()
  if (lowerCaseInput.includes('best spots')) {
    return { type: 'BEST_SPOTS', location: 'Kerala' } // You can add more locations and queries as needed
  }
  // Add more parsing logic for other types of queries if necessary
  return { type: 'UNKNOWN' }
}

export default parseMessage
