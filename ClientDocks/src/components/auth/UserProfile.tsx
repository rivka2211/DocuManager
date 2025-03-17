import Avatar from '@mui/material/Avatar';
import { useContext, useEffect } from 'react';
import { Box, Tooltip } from '@mui/material';
import { UserContext } from './UserReducer';
import UpdateDetails from './UpdateDetails';

function stringToColor(string: string) {
  let hash = 0;
  let i;

  for (i = 0; i < string.length; i += 1) {
    hash = string.charCodeAt(i) + ((hash << 5) - hash);
  }

  let color = '#';

  for (i = 0; i < 3; i += 1) {
    const value = (hash >> (i * 8)) & 0xff;
    color += `00${value.toString(16)}`.slice(-2);
  }
  /* eslint-enable no-bitwise */

  return color;
}

function stringAvatar(name: string) {
  return {
    sx: {
      bgcolor: stringToColor(name),
    },
    children: `${name.split(' ')[0][0]}${name.split(' ')[1][0]}`,
  };
}

export default function UserProfile() {

  const [state] = useContext(UserContext)
  useEffect(() => {
    document.title = `Hello: ${state.firstName}`;
    console.log("User profile updated:", state);
  }, [state]);
  const userName = `${state.firstName} ${state.lastName}`;
  return (
    <Box sx={{ position: 'absolute', top: 0, left: 0, padding: '15px' }}>
      <Tooltip title={userName} style={{margin:"15px"}} arrow>
        <Avatar {...stringAvatar(userName)} />
      </Tooltip>
      <UpdateDetails />
    </Box>
  );
}
