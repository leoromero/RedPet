import { useState } from 'react'

const useOpen = () => {

    const [isOpen, setIsOpen] = useState(false)

    const toggle = () => setIsOpen(!isOpen);

    return { isOpen, toggle }
}

export default useOpen;